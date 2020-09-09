using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class PhieuNhapKhoViewModel
    {
        public string MaPhieuNhapKho { get; set; }
        public string MaKhachHang { get; set; }
        public string NguoiGiaoHang { get; set; }
        public string DienGiai { get; set; }
        public Nullable<int> ChungTuGoc { get; set; }
        public Nullable<System.DateTime> NgayHoachToan { get; set; }
        public Nullable<System.DateTime> NgayChungTu { get; set; }
        public string ChungTuThamChieu { get; set; }
        public string MaSoNhanVien { get; set; }

    }
}