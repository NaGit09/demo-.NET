using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Seminar.Data;

namespace Project_Seminar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ShopContext _shopContext;

        public TaiKhoanController(ShopContext shopContext) {

            _shopContext = shopContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var data = _shopContext.Taikhoans.ToList();
            return Ok(data);

        }
        [HttpPost]
        public IActionResult Add(int id, string pass)
        {
            var taikhoan = new Taikhoan
            {
                KhachHangId = id,
                MatKhau = pass

            };
            _shopContext.Add(taikhoan);
            try
            {
                _shopContext.SaveChanges();
                return Ok(taikhoan);
            }
            catch
            {
                return StatusCode(500, "Co loi xay ra khi luu");

            }
        }



    }
}
