using System;
using System.Collections.Generic;

namespace DemoMVC.Data;

//Được tạo ra từ tools của Entity FrameWork Core
public partial class Hanghoa
{
    public int MaHang { get; set; }

    public string TenHang { get; set; } = null!;

    public decimal DonGia { get; set; }

    public int SoLuongTon { get; set; }

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual ICollection<Chitietgiohang> Chitietgiohangs { get; set; } = new List<Chitietgiohang>();
}
