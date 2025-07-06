using AB.Data;
using AB.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<PayPalClient>(provider => new PayPalClient(
    clientId: "ATr0Zckn8Ctk-lfpdLgMLoud6qA9K9-fI8M5QwrH9n0yrlGtA7L14qpeJ8PRD7kX5BxyOM8K7bSgtSgT",
    clientSecret: "ENGi6h51yt7wvjqMlKV4mmRsQJiA6WEwMyg9POLXs4CTXF1pVUMAlABSSuN74Zwv_cx10bL1MGK0P21Q",
    useSandbox: true // Set to false in production
));
builder.Services.AddHttpClient<PayPalClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
//static void ConfigureServices(IServiceCollection services)
//{
//    // Register PayFastService as a singleton, or transient depending on the context
//    services.AddSingleton<PayFastService>();  // Use AddTransient<PayFastService>() if you need a new instance for each request.

//    // Other service registrations...
//}




