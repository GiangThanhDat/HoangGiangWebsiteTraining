
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class DonDatHangViewModel
    {
        public string MaDonDatHang { get; set; }
        public string MaKhachHang { get; set; }
        public string NguoiNhanHang { get; set; }
        public string DienGiai { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<int> MaDieuKhoan { get; set; }
        public Nullable<double> SoNgayDuocNo { get; set; }
        public Nullable<System.DateTime> NgayDonHang { get; set; }
        public Nullable<int> MaTinhTrang { get; set; }
        public Nullable<System.DateTime> NgayGiaoHang { get; set; }
        public Nullable<int> MaLoaiTien { get; set; }
        public Nullable<double> TyGia { get; set; }
        public Nullable<double> TongTienHang { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public Nullable<double> TongChietKhau { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
    }
}