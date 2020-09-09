using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChiTietLapRapThaoDoViewModel
    {
        public int MaChiTietLapRapThaoDo { get; set; }
        public string MaLapRapThaoDo { get; set; }
        public string MaHang { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> ThanhTien { get; set; }
    }
}