using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Project_Seminar.Data;
using Project_Seminar.Models;
using System.Diagnostics;

namespace Project_Seminar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChitietgiohangController : ControllerBase
    {
        private readonly ShopContext _shopContext;
        private readonly DateOnly current = DateOnly.FromDateTime(DateTime.Now);


        public ChitietgiohangController(ShopContext shopContext)
        {
            _shopContext = shopContext;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _shopContext.Chitietgiohangs.ToList();
            return Ok(data);

        }
        [HttpPost]
        public IActionResult Add(int maHang, int soLuong, int khachhangId)
        {
            var giohang = _shopContext.Giohangs.FirstOrDefault(gh => gh.KhachHangId == khachhangId);
            if (giohang == null)
            {
                 giohang = new Giohang
                {
                    NgayTao = current,
                    KhachHangId = khachhangId,
                };
                _shopContext.Giohangs.Add(giohang); 
                
                _shopContext.SaveChanges();
     

            }
            var chitietgiohang = _shopContext.Chitietgiohangs.FirstOrDefault(c => c.MaGioHang == giohang.MaGioHang && c.MaHang == maHang);
            if (chitietgiohang != null)
            {
                chitietgiohang.SoLuong += soLuong;
                _shopContext.Update(chitietgiohang);

            }
            else
            {
                chitietgiohang = new Chitietgiohang
                {
                    MaGioHang = giohang.MaGioHang,
                    MaHang = maHang,
                    SoLuong = soLuong,
                };
                _shopContext.Add(chitietgiohang);
            }


            try
            {
                giohang.Chitietgiohangs.Add(chitietgiohang);
                _shopContext.SaveChanges();
                return Ok();
                
            }
            catch 
            {
                return StatusCode(500, "Co loi xay ra khi them");

            }

        }
        [HttpPut]
        public IActionResult EditGioHang(int maChiTiet, int soLuong)
        {
            var data = _shopContext.Chitietgiohangs.SingleOrDefault(gh => gh.MaChiTiet == maChiTiet);
            if (data == null)
            {
                return NotFound();
            }       
            data.SoLuong = soLuong;
            try
            {
                _shopContext.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Co loi xay ra khi sua");

            }

        }
        [HttpDelete]
        public IActionResult DeleteChitietDonHang(int maChiTiet)
        {
            var data = _shopContext.Chitietgiohangs.FirstOrDefault(gh => gh.MaChiTiet == maChiTiet);

            if(data == null)
            {
                return NotFound();  
            }
            _shopContext.Remove(data);

            try
            {
                
                _shopContext.SaveChanges();
                return Ok();

            }
            catch
            {
                return StatusCode(500, "Co loi trong luc xoa thong tin");

            }


        } 
       


    }
}
