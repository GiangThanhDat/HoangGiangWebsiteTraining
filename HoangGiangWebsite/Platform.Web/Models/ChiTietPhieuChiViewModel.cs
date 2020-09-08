using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChiTietPhieuChiViewModel
    {
        public int MaCTPC { get; set; }
        public string MaPhieuChi { get; set; }
        public string MaHang { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> SoTien { get; set; }
        public string DienGiai { get; set; }
        public string SoTaiKhoanCo { get; set; }
        public string SoTaiKhoanNo { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string TaiKhoanNganHang { get; set; }
        public string MucThuChi { get; set; }
        public string DonVi { get; set; }
        public string CongTrinh { get; set; }
        public string HopDongBan { get; set; }
        public string MaThongKe { get; set; }
        public string KhoanMucCP { get; set; }
        public string DoiTuongDHCP { get; set; }
        public string DonDatHang { get; set; }
        public string DonMuaHang { get; set; }
    }
}