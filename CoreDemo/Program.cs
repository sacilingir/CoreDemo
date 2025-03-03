using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddSession();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
//proje seviyesinde auth.

builder.Services.AddMvc();
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    }
    );
//yetkili olmadýðýn sayfaya gittiðinde hata vermek yerine bu dizine gidecek.


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5); //Oturum çerezinin süresini 5 dakika olarak belirler. (ExpireTimeSpan)

    options.LoginPath = "/Login/Index";
    options.SlidingExpiration = true; //Kullanýcý aktif kaldýkça oturum süresini otomatik olarak yeniler. (SlidingExpiration)
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

//app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(


    name: "default",
    pattern: "{controller=Category}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.Run();
