using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Project_Seminar.Data;

public partial class Donhang
{
    public int MaDonHang { get; set; }

    public int? MaGioHang { get; set; }

    public decimal TongTien { get; set; }

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    [JsonIgnore]

    public virtual Giohang? MaGioHangNavigation { get; set; }
}
