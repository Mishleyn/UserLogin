using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using UserLogin.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    // ��������� ��������� Antiforgery-�����
    options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
});

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

// ��������� � ���������� ������� Razor Pages
builder.Services.AddRazorPages();

builder.Services.AddSession();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// ��������� ��������� ������������� ��� Razor Pages
app.MapRazorPages();

app.UseSession();

app.MapFallbackToPage("/Create");

app.Run();