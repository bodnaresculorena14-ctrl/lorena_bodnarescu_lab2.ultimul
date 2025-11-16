using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using lorena_bodnarescu_lab2.ultimul.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Context pentru baza de date principalã
builder.Services.AddDbContext<lorena_bodnarescu_lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("lorena_bodnarescu_lab2ultimulContext")));

// Context pentru Identity
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddRazorPages();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
