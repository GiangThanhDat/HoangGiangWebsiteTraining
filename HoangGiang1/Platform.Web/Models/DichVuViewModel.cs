using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class DichVuViewModel
    {
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string DonViTinh { get; set; }
        public Nullable<int> DonGia { get; set; }
        public Nullable<double> VAT { get; set; }
        public Nullable<double> ChietKhau { get; set; }
    }
}