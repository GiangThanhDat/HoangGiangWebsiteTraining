using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Model
{
   public class getphieunhapxuatkho
    {
        public string MaPhieuXuat { get; set; }
        public string MaPhieuNhapKho { get; set; }
        public Nullable<System.DateTime> NgayHoachToan { get; set; }
        public Nullable<System.DateTime> NgayChungTu { get; set; }
        public string DienGiai { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
        public string NguoiGiaoHang { get; set; }
        public string NguoiNhan { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string LyDoXuat { get; set; }
        public Nullable<bool> DaGhiSo { get; set; }
        public Nullable<int> ChungTuGoc { get; set; }

    }
}
