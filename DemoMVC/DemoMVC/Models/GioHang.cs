using DemoMVC.Data;

namespace DemoMVC.Models
{
    public class GioHang
    {
        public int MaGioHang { get; set; }

        public int KhachHangId { get; set; }

        public DateOnly NgayTao { get; set; }

        public virtual ICollection<Chitietgiohang> Chitietgiohangs { get; set; } = new List<Chitietgiohang>();

        public virtual ICollection<Donhang> Donhangs { get; set; } = new List<Donhang>();
    }
}
