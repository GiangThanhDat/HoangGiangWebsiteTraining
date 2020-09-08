using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class PhieuXuat_BanHangViewModel
    {
        public string MaPhieuXuat { get; set; }
        public string MaKhachHang { get; set; }
        public string NguoiNhan { get; set; }
        public string LyDoXuat { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<int> ChungTuGoc { get; set; }
        public Nullable<System.DateTime> NgayHoachToan { get; set; }
        public Nullable<System.DateTime> NgayChungTu { get; set; }
        public Nullable<int> MaDieuKhoan { get; set; }
        public Nullable<double> SoNgayDuocNo { get; set; }
        public Nullable<System.DateTime> HanThanhToan { get; set; }
        public Nullable<int> MaLoaiTien { get; set; }
        public Nullable<double> TyGia { get; set; }
        public Nullable<double> TongTienHang { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
        public string MaChungTuBanHang { get; set; }
        public string MaTraLaiHangBan { get; set; }

    }
}