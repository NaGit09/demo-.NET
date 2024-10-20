using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Seminar.Data;
using Project_Seminar.Models;

namespace Project_Seminar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly ShopContext _shopContext;

        public HangHoaController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        [ResponseCache(Duration = 30)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _shopContext.Hanghoas.ToList();

            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = _shopContext.Hanghoas.SingleOrDefault(hh => hh.MaHang == id);
                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch 
            {
                return StatusCode(500, "Co loi xay ra khi tim kiem");
            }


        }
       
        
    }
}
