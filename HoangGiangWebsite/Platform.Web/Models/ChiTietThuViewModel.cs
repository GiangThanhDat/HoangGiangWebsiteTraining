using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChiTietThuViewModel
    {
        public int MaCTPT { get; set; }
        public string MaPhieuThu { get; set; }
        public string MaHang { get; set; }
        public int SoLuong { get; set; }
        public Nullable<double> SoTien { get; set; }
        public string DienGiai { get; set; }
        public string SoTaiKhoanCo { get; set; }
        public string SoTaiKhoanNo { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string TaiKhoanNganHang { get; set; }
        public string MucThuChi { get; set; }
        public string DonVi { get; set; }
        public string CongTrinh { get; set; }
        public string HopDongBan { get; set; }
        public string MaThongKe { get; set; }

    }
}