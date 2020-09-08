using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChiTietDonDatHangViewModel
    {
        public int MaChiTietDonDatHang { get; set; }
        public string MaDonDatHang { get; set; }
        public string MaHang { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> SoLuongDaGiao { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }

       
    }
}