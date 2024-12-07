using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;
using System.Security.Claims;
using Tarifler.Data;
using Tarifler.Service.Concrete;
using Tarifler.Service.Abstract;
using System.Reflection;
using ServiceStack;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Veri tabaný tanýt
builder.Services.AddDbContext<TarifDbContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Account/SignIn"; //Login ana sayfasý nerede
        x.AccessDeniedPath = "/AccessDenied"; //Kullanýcý yetkin yoksa yönlendirilecek sayfa ismi
        x.Cookie.Name = "Account"; //Login için Cookie adý ne olsun
        x.Cookie.MaxAge = TimeSpan.FromDays(7); //Cookie kaç gün saklý kalsýn
        x.Cookie.IsEssential = true; //Cookie kalýcý olsun
    });

//Oturum Yetkilendirme Ayarlarý
builder.Services.AddAuthorization(x => {
    x.AddPolicy("AdminPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    x.AddPolicy("MemberPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Member", "Admin"));
    x.AddPolicy("GuestPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Guest", "Member", "Admin"));
});

//interface tanýmlama
builder.Services.AddScoped(typeof(IService<>), typeof(EfService<>));

//AutoMapping tanýt
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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

app.UseAuthentication();
app.UseAuthorization();

//Area alaný tanýtma
app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
