using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Model
{
  public  class getdonmuahang
    {
        public string MaDonMuaHang { get; set; }
        public string MaNhaCungCap { get; set; }
        public string DienGiai { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<int> MaDieuKhoan { get; set; }
        public Nullable<double> SoNgayDuocNo { get; set; }
        public Nullable<System.DateTime> NgayDonHang { get; set; }
        public int MaTinhTrang { get; set; }
        public Nullable<System.DateTime> NgayGiaoHang { get; set; }
        public Nullable<int> MaLoaiTien { get; set; }
        public Nullable<double> TyGia { get; set; }
        public Nullable<double> TongTienHang { get; set; }
        public Nullable<double> TienThue { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
        public string TenTinhTrang { get; set; }
        public string TenNhaCungCap { get; set; }
        public string HoVaTen { get; set; }
        public string DiaChi { get; set; }
        public string MaSoThue { get; set; }
        public string VietTat { get; set; }
    }
}
