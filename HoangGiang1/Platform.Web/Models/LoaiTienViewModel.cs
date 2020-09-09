using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class LoaiTienViewModel
    {
        public int MaLoaiTien { get; set; }
        public string TenLoaiTien { get; set; }
        public string VietTat { get; set; }
        public string MenhGia { get; set; }
        public Nullable<double> TyGia_VND { get; set; }
    }
}