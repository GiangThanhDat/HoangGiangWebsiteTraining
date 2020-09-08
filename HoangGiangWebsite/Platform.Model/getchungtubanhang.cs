using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Model
{
    public class getchungtubanhang
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
        public string HoVaTen { get; set; }
        public string TenKhachHang { get; set; }
        public string VietTat { get; set; }
        public string MaSoThue { get; set; }
        public string DiaChi { get; set; }
        public string NguoiLienHe { get; set; }
        public string TenDieuKhoan { get; set; }
        public Nullable<bool> DaGhiSo { get; set; }
        public string TenCoSo { get; set; }
        public string MaCoSo { get; set; }

        public string MaChucVu { get; set; }
        public string TenChucVu { get; set; }
       

        public getCoSo CoSo { get; set; }

    }
}
