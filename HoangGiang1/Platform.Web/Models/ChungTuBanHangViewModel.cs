using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChungTuBanHangViewModel
    {
        public string MaChungTuBanHang { get; set; }
        public string MaKhachHang { get; set; }
        public string DienGiai { get; set; }
        public string MaSoNhanVien { get; set; }
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
        public Nullable<bool> DaGhiSo { get; set; }
        public string MaSoBaoGia { get; set; }
        public string MaPhieuMoi { get; set; }
        public string MaPhieuGoc { get; set; }
        public string NhanVienThayDoi { get; set; }
        public string CoSoThayDoi { get; set; }
        public Nullable<bool> DaThayDoi { get; set; }
        public Nullable<DateTime> NgayThayDoi { get; set; }



        public KhachHang KhachHang { get; set; }
        public IEnumerable<NhanVienVangMat> NhanVienVangMat { get; set; }
    }
}