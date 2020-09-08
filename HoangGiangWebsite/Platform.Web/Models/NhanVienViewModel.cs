using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class NhanVienViewModel
    {
        public string MaSoNhanVien { get; set; }
        public string HoVaTen { get; set; }
        public string GioiTinh { get; set; }
        public string SoCMND { get; set; }
        public System.DateTime NgayCapCMND { get; set; }
        public string NoiCapCMND { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string TinhTrangHonNhan { get; set; }
        public string QuocTich { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string HoTenLienHeKhanCap { get; set; }
        public string QuanHeLienHeKhanCap { get; set; }
        public string DiaChiLienHeKhanCap { get; set; }
        public string SDTLienHeKhanCap { get; set; }
        public string Hinh { get; set; }
        public  int Bac { get; set; }
        public string TrangThai { get; set; }
        public string MaCoSo { get; set; }
        public string MaChucVu { get; set; }
        public string MaSoThue { get; set; }
        public string SoTaiKhoanNganHang { get; set; }
        public string TenNganHang { get; set; }
        public string ChiNhanh { get; set; }
    }
}