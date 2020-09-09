
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class LapRapThaoDoViewModel
    {
        public string MaLapRapThaoDo { get; set; }
        public string MaHang { get; set; }
        public string MaThanhPham { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public string DienGiai { get; set; }
        public Nullable<double> DonGia { get; set; }
        public Nullable<double> ThanhTien { get; set; }
    }
}