using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChiTietHopDongMuaViewModel
    {
        public int MaChiTietHopDongMua { get; set; }
        public string MaHopDongMua { get; set; }
        public string MaHang { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public Nullable<double> ThanhTien { get; set; }

    }
}