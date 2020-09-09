using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class LenhSanXuat_NVLViewModel
    {
        public int MaLenhSanXuat_NVL { get; set; }
        public string MaLenhSanXuat { get; set; }
        public string MaHang { get; set; }
        public Nullable<int> SoLuong_1DonVi { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string DoiTuongDHCP { get; set; }
        public string KhoanMucCP { get; set; }
        public string MaThongKe { get; set; }
    }
}