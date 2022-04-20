using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using MvcMovie.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
// Replace with your connection string.
        // var connectionString = "server=localhost;user=root;password=1234;database=ef";

var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

// string connectionString = "server=localhost;database=rocket-elevators;user=martincote;password=dragonballz";

var connectionString = builder.Configuration.GetConnectionString("MvcMovieIdentityDbContextConnection");;

builder.Services.AddDbContext<MvcMovieIdentityDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));;

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MvcMovieIdentityDbContext>();;

builder.Services.AddDbContext<ElevatorsContext>(options =>
    options.UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

// if (builder.Environment.IsDevelopment())
// {
//     builder.Services.AddDbContext<MvcMovieContext>(options =>
//         options.UseMySql(connectionString, serverVersion));;
        // options.UseMySql(builder.Configuration.GetConnectionString("MvcMovieContext")));
// }
// else
// {
//     builder.Services.AddDbContext<MvcMovieContext>(options =>
//         options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMvcMovieContext")));
// }
// im pretty sure this is extra
// builder.Services.AddDbContext<MvcMovieContext>(options =>
//     options.UseSqlite(builder.Configuration.GetConnectionString("MvcMovieContext") ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    // var services = scope.ServiceProvider;

    // SeedData.Initialize(services);
}

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    // pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();
app.MapRazorPages();    
    
// app.UsePathBase("/Identity/Account/Login");
app.Run();
