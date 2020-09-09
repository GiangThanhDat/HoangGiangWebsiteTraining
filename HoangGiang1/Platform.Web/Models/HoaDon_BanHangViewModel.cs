using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class HoaDon_BanHangViewModel
    {
        public string MaHoaDon { get; set; }
        public string MaKhachHang { get; set; }
        public string TKNganHang { get; set; }
        public string NguoiMuaHang { get; set; }
        public string HinhThucTT { get; set; }
        public string MauSoHD { get; set; }
        public string KyHieuHD { get; set; }
        public Nullable<System.DateTime> NgayHoaDon { get; set; }
        public Nullable<int> MaDieuKhoan { get; set; }
        public Nullable<double> SoNgayDuocNo { get; set; }
        public Nullable<System.DateTime> HanThanhToan { get; set; }
        public Nullable<double> TyGia { get; set; }
        public Nullable<double> TongTienHang { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
        public Nullable<int> MaLoaiTien { get; set; }
        public string MaChungTuBanHang { get; set; }
        public string MaSoNhanVien { get; set; }


    }
}