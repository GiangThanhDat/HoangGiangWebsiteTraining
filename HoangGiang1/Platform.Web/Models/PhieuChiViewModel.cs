using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class PhieuChiViewModel
    {
        public string MaPhieuChi { get; set; }
        public string MaSoNhanVien { get; set; }
        public string MaNhaCungCap { get; set; }
        public Nullable<int> MaLoaiChi { get; set; }
        public Nullable<int> MaTinhTrang { get; set; }
        public string LyDoChi { get; set; }
        public string DienGiai { get; set; }
        public Nullable<System.DateTime> NgayHoachToan { get; set; }
        public DateTime NgayChungTu { get; set; }
        public Nullable<double> TongTienDichVu { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
        public Nullable<int> ChungTuGoc { get; set; }
        public Nullable<int> MaLoaiTien { get; set; }
        public Nullable<double> TyGia { get; set; }
        public string NguoiNop { get; set; }
        public Nullable<bool> DaGhiSo { get; set; }

    }
}