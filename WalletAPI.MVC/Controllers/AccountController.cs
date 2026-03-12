using Microsoft.AspNetCore.Mvc;
using WalletAPI.BusinessLogic.Builder;
using WalletAPI.BusinessLogic.Contracts;
using WalletAPI.MVC.Models.AccountModels;

namespace WalletAPI.MVC.Controllers;

// Головні зміни:

// ControllerBase ➜ Controller

// Немає [ApiController]

// Немає [FromBody]

// Повертаємо View() або RedirectToAction()

// Додаємо [ValidateAntiForgeryToken]

// Методи розділені на GET + POST для форм
public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly IAccountService _accountService;
    private readonly IAccountBuilder _builder;

    public AccountController(
        ILogger<AccountController> logger,
        IAccountService accountService,
        IAccountBuilder accountBuilder)
    {
        _logger = logger;
        _accountService = accountService;
        _builder = accountBuilder;
    }
    
    // GET: /Account
    public async Task<IActionResult> Index()
    {
        try
        {
            var accounts = await _accountService.Get();
            var model = accounts.Select(a => new AccountViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                Amount = a.Amount,
                Type = a.Type,
                Currency = a.Currency,
                BankType = a.BankType,
                LastModified = a.LastModified
            }).ToList();
            
            return View(model);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to fetch accounts");
            return View("Error");
        }
    }

    // GET: /Account/Details/5
    public async Task<IActionResult> Details(string id)
    {
        try
        {
            var account = await _accountService.Get(id);
            if (account == null)
                return NotFound();

            var model = new AccountViewModel
            {
                Id = account.Id,
                Name = account.Name,
                Amount = account.Amount,
                Type = account.Type,
                Currency = account.Currency,
                BankType = account.BankType,
                LastModified = account.LastModified
            };
            
            return View(model);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to fetch account");
            return View("Error");
        }
    }

    // GET: /Account/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Account/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateAccountViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var entity = _builder
            .SetName(model.Name)
            .SetBalance(model.Amount)
            .SetCurrency(model.Currency)
            .SetType(model.Type)
            .SetBankIntegration(model.BankType)
            .SetLastModifiedDate(DateTime.UtcNow)
            .Build();

        try
        {
            await _accountService.Add(entity);
            _logger.LogInformation($"Account {entity.Id} created");

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create account");
            ModelState.AddModelError("", "Error creating account");
            return View(model);
        }
    }

    // GET: /Account/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        var account = await _accountService.Get(id);

        if (account == null)
            return NotFound();

        var model = new EditAccountViewModel
        {
            Id = account.Id,
            Name = account.Name,
            Amount = account.Amount,
            Type = account.Type,
            Currency = account.Currency,
            BankType = account.BankType
        };

        return View(model);
    }

    // POST: /Account/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditAccountViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var entity = _builder
            .SetId(model.Id)
            .SetName(model.Name)
            .SetBalance(model.Amount)
            .SetCurrency(model.Currency)
            .SetType(model.Type)
            .SetBankIntegration(model.BankType)
            .SetLastModifiedDate(DateTime.UtcNow)
            .Build();

        try
        {
            await _accountService.Update(entity);
            TempData["Success"] = "Account created successfully";
            _logger.LogInformation($"Account {model.Id} updated");

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update account");
            ModelState.AddModelError("", "Error updating account");
            return View(model);
        }
    }

    // POST: /Account/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _accountService.Remove(id);
            _logger.LogInformation($"Account {id} successfully deleted");

            TempData["Success"] = "Account deleted successfully";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to delete account with id={id}");
            TempData["Error"] = "Failed to delete account";
            return View("Error");
        }
    }
}