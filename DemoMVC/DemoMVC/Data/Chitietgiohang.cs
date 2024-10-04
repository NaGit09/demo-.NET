using System;
using System.Collections.Generic;

namespace DemoMVC.Data;

//Được tạo ra từ tools của Entity FrameWork Core

public partial class Chitietgiohang
{
    public int MaChiTiet { get; set; }

    public int MaGioHang { get; set; }

    public int MaHang { get; set; }

    public int SoLuong { get; set; }

    public virtual Giohang MaGioHangNavigation { get; set; } = null!;

    public virtual Hanghoa MaHangNavigation { get; set; } = null!;
}
