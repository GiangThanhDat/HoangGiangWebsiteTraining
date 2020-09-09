using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class HangHoa_DonViTinhViewModel
    {
        public int MaDonViTinh { get; set; }
        public string MaHang { get; set; }
        public Nullable<double> DonGia { get; set; }
    }
}