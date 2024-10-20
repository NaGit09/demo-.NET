using Project_Seminar.Data;

namespace Project_Seminar.Models
{
    public class GioHangVM
    {
        public int MaGioHang { get; set; }

        public int KhachHangId { get; set; }

        public DateOnly NgayTao { get; set; }

        public virtual ICollection<Chitietgiohang> Chitietgiohangs { get; set; } = new List<Chitietgiohang>();

        public virtual ICollection<Donhang> Donhangs { get; set; } = new List<Donhang>();
    }
}
