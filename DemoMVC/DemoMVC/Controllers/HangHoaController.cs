using DemoMVC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Seminar.Models;
using static Project_Seminar.Models.HangHoaVM;

namespace Project_Seminar.Controllers
{
 
    public class HangHoaController : Controller
    {
        private readonly ShopContext _shopContext; //Chỉ có thể gán 1 lần cho trường này

        //Viết Contructor
        public HangHoaController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        // Trả về view Index
        public IActionResult Index()
        {
            var data = _shopContext.Hanghoas.Select(dh => new HangHoaVM 
            //Truy cập vào DbSet HangHoas để có thể truy vấn dữ liệu từ 
            // bảng HangHoa, sau đó ánh xạ đến 1 đối tượng HangHoaVM mới 
            {
                MaHang = dh.MaHang,
                TenHang = dh.TenHang,
                DonGia = dh.DonGia,
                SoLuongTon = dh.SoLuongTon,

            });
            return View(data); //Trả về View của Index kèm dữ liệu 
        }

        // Trả về view GioHang
        public IActionResult GioHang()
        {
            return View();
        }
        // Trả về view DonHang
        public IActionResult DonHang()
        {
            return View();
        }
        // Trả về view Index
        public IActionResult TrangChu()
        {
            return View();
        }

       

    }
}
