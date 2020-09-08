using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChiTietChungTuMuaHangViewModel
    {
        public int MaChiTietChungTuMuaHang { get; set; }
        public string MaChungTuMuaHang { get; set; }
        public string MaHang { get; set; }
        public string Kho { get; set; }
        public string TKKho { get; set; }
        public string TKCongNo { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public string ChiPhiMuaHang { get; set; }
        public string GiaTriNhapKho { get; set; }
        public string SoLo { get; set; }
        public string DoiTuongDHCP { get; set; }
        public string CongTrinh { get; set; }
        public string MaHopDongMua { get; set; }
        public string MaDonMuaHang { get; set; }
        public string MaThongKe { get; set; }
    }
}