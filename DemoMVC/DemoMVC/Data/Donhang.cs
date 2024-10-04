using System;
using System.Collections.Generic;

namespace DemoMVC.Data;

//Được tạo ra từ tools của Entity FrameWork Core

public partial class Donhang
{
    public int MaDonHang { get; set; }

    public int? MaGioHang { get; set; }

    public decimal TongTien { get; set; }

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual Giohang? MaGioHangNavigation { get; set; }
}
