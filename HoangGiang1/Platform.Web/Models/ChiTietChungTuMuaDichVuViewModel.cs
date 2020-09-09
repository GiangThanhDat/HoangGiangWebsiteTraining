using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ChiTietChungTuMuaDichVuViewModel
    {
        public int MaChiTietChungTuMuaDichVu { get; set; }
        public string MaChungTuMuaDichVu { get; set; }
        public string MaDichVu { get; set; }
        public string TKChiPhi_TKKho { get; set; }
        public string TKCongNo { get; set; }
        public string DoiTuong { get; set; }
        public string TenDoiTuong { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> ThanhTien { get; set; }
    }
}