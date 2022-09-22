using FunOlympic1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using FunOlympic1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddDefaultTokenProviders()
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddSingleton<IEmailSender, EmailSender>();

builder.Services.AddAuthentication().AddFacebook(options =>
{
    options.AppId = "833118264715574";
    options.AppSecret = "7a35a3273f4f6a7e02cf976a3422ec5e";
});
builder.Services.AddAuthentication().AddGoogle(options =>
{
    options.ClientId = "926973631004-24uvpqsdgq1cn5tg2cbm0g7gtkv5pmhs.apps.googleusercontent.com";
    options.ClientSecret = "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";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
