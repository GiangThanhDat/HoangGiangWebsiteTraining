using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChungTuMuaHangViewModel
    {
        public string MaChungTuMuaHang { get; set; }
        public string MaNhaCungCap { get; set; }
        public string NguoiGiaoHang { get; set; }
        public string DienGiai { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<int> ChungTuGoc { get; set; }
        public string DieuKhoanTT { get; set; }
        public Nullable<double> SoNgayDuocNo { get; set; }
        public Nullable<System.DateTime> HanThanhToan { get; set; }
        public Nullable<int> MaLoaiTien { get; set; }
        public Nullable<double> TyGia { get; set; }
        public Nullable<System.DateTime> NgayHoachToan { get; set; }
        public Nullable<System.DateTime> NgayChungTu { get; set; }
        public Nullable<double> TongTienHang { get; set; }
        public Nullable<double> ChiPhiGiaoHang { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> GiaTriNhapKho { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
    }
}