using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Seminar.Data;
using Project_Seminar.Models;

namespace Project_Seminar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiohangController : ControllerBase
    {
        private readonly ShopContext _shopContext;

        public GiohangController(ShopContext shopContext) {
        
        _shopContext = shopContext; 
         
        }
        [HttpGet]
        public IActionResult GetGioHang()
        {
            var gioHang = _shopContext.Giohangs
                .Include(gh => gh.Chitietgiohangs);

            if (gioHang == null)
            {
                return NotFound();
            }

            return Ok(gioHang);
        }

        
      
    }
}
