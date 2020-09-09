using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class TraLaiHangMuaViewModel
    {
        public string MaTraLaiHangMua { get; set; }
        public string MaNhaCungCap { get; set; }
        public string NguoiNhanHang { get; set; }
        public string DienGiai { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<int> ChungTuGoc { get; set; }
        public Nullable<int> MaLoaiTien { get; set; }
        public Nullable<double> TyGia { get; set; }
        public Nullable<System.DateTime> NgayHoachToan { get; set; }
        public Nullable<System.DateTime> NgayChungTu { get; set; }
        public Nullable<double> TongTienHang { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
        public Nullable<bool> DaGhiSo { get; set; }

    }
}