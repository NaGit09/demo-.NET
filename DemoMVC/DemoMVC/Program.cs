using DemoMVC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Thêm xử lí SQL vào dự án, lấy tên của chuỗi kết nối bên file appsettings.json
builder.Services.AddDbContext<ShopContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Shop"));

});
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

app.UseAuthorization();

//Định nghĩa đường dẫn mặc định cho trang web
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HangHoa}/{action=Index}/{id?}"); 
// Cụ thể được ánh xạ đến Controller HangHoa và method Index
// Vậy lúc mở lên mặc định sẽ hiện ra View của method Index trong Controller


app.Run();
