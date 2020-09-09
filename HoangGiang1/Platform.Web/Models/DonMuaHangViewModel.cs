using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class DonMuaHangViewModel
    {
        public string MaDonMuaHang { get; set; }
        public string MaNhaCungCap { get; set; }
        public string DienGiai { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<int> MaDieuKhoan { get; set; }
        public Nullable<double> SoNgayDuocNo { get; set; }
        public Nullable<System.DateTime> NgayDonHang { get; set; }
        public int MaTinhTrang { get; set; }
        public Nullable<System.DateTime> NgayGiaoHang { get; set; }
        public Nullable<int> MaLoaiTien { get; set; }
        public Nullable<double> TyGia { get; set; }
        public Nullable<double> TongTienHang { get; set; }
        public Nullable<double> TienThue { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
    }
}