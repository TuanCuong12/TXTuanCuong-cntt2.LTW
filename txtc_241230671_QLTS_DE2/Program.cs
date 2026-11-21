using Microsoft.EntityFrameworkCore;
using txtc_241230671_QLTS_DE2.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    // Thông báo khi nhập chữ vào ô số (Câu 5.2)
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(name => $"{name} phải là số.");
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((value, name) => $"{name} phải là số.");
});

builder.Services.AddDbContext<QLTaiSanContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLTaiSan")));

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