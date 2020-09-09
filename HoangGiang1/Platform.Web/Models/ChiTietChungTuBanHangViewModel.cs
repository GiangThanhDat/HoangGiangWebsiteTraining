using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChiTietChungTuBanHangViewModel
    {
        public int MaChiTietChungTuBanHang { get; set; }
        public string MaChungTuBanHang { get; set; }
        public string MaHang { get; set; }
        public string TKCongNo_ChiPhi { get; set; }
        public string TKDoanhThu { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public int MaDonViTinh { get; set; }

    }
}