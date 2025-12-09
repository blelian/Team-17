using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication; // <-- important for AddGoogle
using ConnectionsManager.Areas.Identity;
using ConnectionsManager.Data;

var builder = WebApplication.CreateBuilder(args);

// --------------------------
// Load configuration
// --------------------------
// builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                      .AddJsonFile("appsettings.Secrets.json", optional: true, reloadOnChange: true); // optional secrets

// --------------------------
// Database
// --------------------------
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// --------------------------
// Identity
// --------------------------
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

// --------------------------
// Application services
// --------------------------
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ZenQuoteService>();


// --------------------------
// Build the app
// --------------------------
var app = builder.Build();

// --------------------------
// Configure HTTP request pipeline
// --------------------------
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Map endpoints
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
