using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CafeneaSite.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/PaginiPentruClienti");
    options.Conventions.AuthorizeFolder("/Cafele");
    options.Conventions.AllowAnonymousToPage("/PaginiPentruClienti/About");
    options.Conventions.AllowAnonymousToPage("/PaginiPentruClienti/Reservation");
    options.Conventions.AllowAnonymousToPage("/Cafele/Index");
    options.Conventions.AuthorizeFolder("/Membrii", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/TipuriArome", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/TipuriBoabe", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/TipuriCafele", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/TipuriLapte", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/TipuriToppinguri", "AdminPolicy");

});



builder.Services.AddDbContext<CafeneaSiteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CafeneaSiteContext") ?? throw new InvalidOperationException("Connection string 'CafeneaSiteContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("CafeneaSiteContext") ?? throw new InvalidOperationException("Connectionstring 'CafeneaSiteContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
