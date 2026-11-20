using Microsoft.EntityFrameworkCore;
using txtc_241230671.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(_ => "Giá phải là số.");
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((v, _) => $"Giá trị '{v}' không hợp lệ.");
});

builder.Services.AddDbContext<QLNhaSachContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLNhaSach")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();