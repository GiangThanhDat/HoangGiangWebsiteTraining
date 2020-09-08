using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class PhieuThuViewModel
    {
        public string MaPhieuThu { get; set; }
        public string MaKhachHang { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<int> MaLoaiThu { get; set; }
        public Nullable<int> MaTinhTrang { get; set; }
        public string LyDoNop { get; set; }
        public string DienGiai { get; set; }
        public Nullable<System.DateTime> NgayHoachToan { get; set; }
        public DateTime NgayChungTu { get; set; }
        public Nullable<double> TongTienHang { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
        public Nullable<bool> DaGhiSo { get; set; }
        public Nullable<int> ChungTuGoc { get; set; }
        public Nullable<int> MaLoaiTien { get; set; }
        public Nullable<double> TyGia { get; set; }
        public string ChungTuThamChieu { get; set; }
        public string NguoiNop { get; set; }

    }
}