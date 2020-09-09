using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChiTietTraLaiHangMuaViewModel
    {
        public int MaChiTietTraLaiHangMua { get; set; }
        public string MaTraLaiHangMua { get; set; }
        public string MaHang { get; set; }
        public string Kho { get; set; }
        public string TKKho { get; set; }
        public string TKCongNo { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public string DienGiaiThue { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public string TKThueGTGT { get; set; }
        public string NhomHHDVMuaVao { get; set; }
        public string SoLo { get; set; }
        public string SoCTMuaHang { get; set; }
        public string SoHDMuaHang { get; set; }
        public string NgayHDMuaHang { get; set; }
        public string MaHopDongMua { get; set; }
        public string MaThongKe { get; set; }
    }
}