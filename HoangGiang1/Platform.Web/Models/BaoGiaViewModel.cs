using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class BaoGiaViewModel
    {
        public string MaSoBaoGia { get; set; }
        public string MaKhachHang { get; set; }
        public string GhiChu { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<System.DateTime> NgayBaoGia { get; set; }
        public Nullable<System.DateTime> HieuLucDen { get; set; }
        public Nullable<int> MaLoaiTien { get; set; }
        public Nullable<double> TyGia { get; set; }
        public Nullable<double> TienHang { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TongTien { get; set; }
    }
}