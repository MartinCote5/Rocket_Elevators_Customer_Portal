using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using MvcMovie.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

// string connectionString = "server=localhost;database=rocket-elevators;user=martincote;password=dragonballz";

var connectionString = builder.Configuration.GetConnectionString("MvcMovieIdentityDbContextConnection");;

builder.Services.AddDbContext<MvcMovieIdentityDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));;

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MvcMovieIdentityDbContext>();;

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
    pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();
app.MapRazorPages();    
    

app.Run();
