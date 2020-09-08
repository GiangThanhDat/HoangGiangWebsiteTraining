using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Model
{
  public  class getgiamgiahangmua
    {

        public string MaGiamGiaHangMua { get; set; }
        public string MaNhaCungCap { get; set; }
       
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
        public string DiaChi { get; set; }
        public string TenNhaCungCap { get; set; }
        public string MaSoThue { get; set; }
        public string TenLoaiTien { get; set; }
        public string HoVaTen { get; set; }
        public string VietTat { get; set; }
        public Nullable<bool> DaGhiSo { get; set; }
    }
}
