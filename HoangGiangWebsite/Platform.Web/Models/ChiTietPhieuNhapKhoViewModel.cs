using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChiTietPhieuNhapKhoViewModel
    {
        public int MaChiTietPhieuNhapKho { get; set; }
        public string MaPhieuNhapKho { get; set; }
        public string MaHang { get; set; }
        public string Kho { get; set; }
        public string TKNo { get; set; }
        public string TKCo { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public string MaLenhSanXuat { get; set; }
    }
}