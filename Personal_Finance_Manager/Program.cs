using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Personal_Finance_Manager;
using Personal_Finance_Manager.Converters;
using ServiceContracts;
using Services;
using Services.Data;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonDateTimeConverter("yyyy-MM-dd"));
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("ConnectionString"));

builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var dbSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    options.UseMySQL($"server=127.0.0.1;user={dbSettings.User};password={dbSettings.Password};database={dbSettings.Database};");
});

builder.Services.AddSingleton<ICategoriesService, CategoriesService>();
builder.Services.AddSingleton<ITransactionsService, TransactionsService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
