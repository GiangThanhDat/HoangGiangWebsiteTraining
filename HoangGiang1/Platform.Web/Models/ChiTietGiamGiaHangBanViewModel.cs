using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChiTietGiamGiaHangBanViewModel
    {
        public int MaChiTietGiamGiaHangBan { get; set; }
        public string MaGiamGiaHangBan { get; set; }
        public string MaHang { get; set; }
        public string TKGiamGia { get; set; }
        public string TKTien { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
    }
}