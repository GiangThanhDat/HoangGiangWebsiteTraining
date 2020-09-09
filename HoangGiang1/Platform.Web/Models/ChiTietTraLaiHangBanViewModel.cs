using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChiTietTraLaiHangBanViewModel
    {
        public int MaChiTietTraLaiHangBan { get; set; }
        public string MaTraLaiHangBan { get; set; }
        public string MaHang { get; set; }
        public string TKTraLai { get; set; }
        public string TKTien { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public string MucThuChi { get; set; }
    }
}