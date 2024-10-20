using System;
using System.Collections.Generic;

namespace Project_Seminar.Data;

public partial class Taikhoan
{
    public int KhachHangId { get; set; }

    public string MatKhau { get; set; } = null!;

    public virtual ICollection<Giohang> Giohangs { get; set; } = new List<Giohang>();
}
