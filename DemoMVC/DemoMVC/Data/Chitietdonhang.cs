using System;
using System.Collections.Generic;

namespace DemoMVC.Data;

//Được tạo ra từ tools của Entity FrameWork Core


public partial class Chitietdonhang
{
    public int MaChiTiet { get; set; }

    public int? MaDonHang { get; set; }

    public int? MaHang { get; set; }

    public int SoLuong { get; set; }

    public decimal DonGia { get; set; }

    public virtual Donhang? MaDonHangNavigation { get; set; }

    public virtual Hanghoa? MaHangNavigation { get; set; }
}
