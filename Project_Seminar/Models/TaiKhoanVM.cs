using Project_Seminar.Data;

namespace Project_Seminar.Models
{
    public class TaiKhoanVM
    {
        public int KhachHangId { get; set; }

        public string MatKhau { get; set; } = null!;

        public virtual ICollection<Giohang> Giohangs { get; set; } = new List<Giohang>();
    }
}
