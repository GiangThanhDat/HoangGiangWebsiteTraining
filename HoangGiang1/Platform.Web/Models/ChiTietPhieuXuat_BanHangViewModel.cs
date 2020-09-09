using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChiTietPhieuXuat_BanHangViewModel
    {
        public int MaChiTietPhieuXuat { get; set; }
        public string MaPhieuXuat { get; set; }
        public string MaHang { get; set; }
        public string TKCongNo_ChiPhi { get; set; }
        public string TKDoanhThu { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public string Kho { get; set; }
        public string TKNo { get; set; }
        public string TKCo { get; set; }
    }
}