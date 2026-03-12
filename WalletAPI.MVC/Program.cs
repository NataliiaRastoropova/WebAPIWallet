using WalletAPI.BusinessLogic.Installers;
using WalletAPI.DataAccess.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDataContext(builder.Configuration.GetConnectionString("WalletDB"))
    .AddTransactions()
    .AddAccounts()
    .AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Змінити структуру URL зробити REST-подібні адреси:
app.MapControllerRoute(
    name: "accounts",
    pattern: "accounts/{action=Index}/{id:int?}", //Додати constraint для id
    defaults: new { controller = "Account" });

app.MapControllerRoute(
    name: "transactions",
    pattern: "transactions/{action=Index}/{id?}",
    defaults: new { controller = "Transaction" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();