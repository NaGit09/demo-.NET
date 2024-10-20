using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Project_Seminar.Data;

public partial class Chitietgiohang
{
    public int MaChiTiet { get; set; }

    public int MaGioHang { get; set; }

    public int MaHang { get; set; }

    public int SoLuong { get; set; }

    [JsonIgnore]
    public virtual Giohang MaGioHangNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Hanghoa MaHangNavigation { get; set; } = null!;
}
