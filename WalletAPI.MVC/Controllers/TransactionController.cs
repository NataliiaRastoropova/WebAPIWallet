using Microsoft.AspNetCore.Mvc;
using WalletAPI.BusinessLogic.Contracts;
using WalletAPI.BusinessLogic.DomainModel;
using WalletAPI.Infrastructure.Enums;
using WalletAPI.MVC.Models.TransactionModels;

namespace WalletAPI.MVC.Controllers;

public class TransactionController : Controller
{
    private readonly ILogger<TransactionController> _logger;
    private readonly ITransactionService _transactionService;
    private readonly ITransactionsSync _transactionsSync;
    
    public TransactionController(
        ILogger<TransactionController> logger,
        ITransactionService transactionService,
        ITransactionsSync transactionsSync)
    {
        _logger = logger;
        _transactionService = transactionService;
        _transactionsSync = transactionsSync;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var transactions = await _transactionService.Get();
            var model = transactions.Select(t => new TransactionViewModel
            {
                Id = t.Id,
                Amount = t.Amount,
                AccountId = t.AccountId,
                Type = t.Type,
                LastModified = t.LastModified
            });
            return View(model); // Views/Transactions/Index.cshtml
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to fetch transactions");
            return View("Error");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        if (string.IsNullOrEmpty(id))
            return NotFound();

        try
        {
            var transaction = await _transactionService.Get(id);
            if (transaction == null)
                return NotFound();
            
            var model =  new TransactionViewModel
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                AccountId = transaction.AccountId,
                Type = transaction.Type,
                LastModified = transaction.LastModified
            };
            return View(model);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to fetch transaction by id");
            return View("Error");
        }
    }
    
    public async Task<IActionResult> ByAccount(string accountId)
    {
        if (string.IsNullOrEmpty(accountId))
            return NotFound();
        
        try
        {
            var transactions = await _transactionService.GetTransactionsByAccount(accountId);
            var model = transactions.Select(t => new TransactionViewModel
            {
                Id = t.Id,
                Amount = t.Amount,
                AccountId = t.AccountId,
                Type = t.Type,
                LastModified = t.LastModified
            });
        
            return View("Index", model);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to fetch transaction by Account id");
            return View("Error");
        }
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateTransactionViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var entity = new Transaction(
            Guid.NewGuid().ToString(),
            model.Amount,
            model.AccountId,
            model.Type,
            DateTime.UtcNow);

        try
        {
            await _transactionService.Create(entity);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create transaction");
            return View("Error");
        }
    }

}