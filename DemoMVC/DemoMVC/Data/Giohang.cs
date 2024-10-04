using System;
using System.Collections.Generic;

namespace DemoMVC.Data;

//Được tạo ra từ tools của Entity FrameWork Core

public partial class Giohang
{
    public int MaGioHang { get; set; }

    public int KhachHangId { get; set; }

    public DateOnly NgayTao { get; set; }

    public virtual ICollection<Chitietgiohang> Chitietgiohangs { get; set; } = new List<Chitietgiohang>();

    public virtual ICollection<Donhang> Donhangs { get; set; } = new List<Donhang>();
}
