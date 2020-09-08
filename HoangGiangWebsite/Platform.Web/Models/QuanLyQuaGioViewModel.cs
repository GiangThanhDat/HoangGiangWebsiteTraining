using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class QuanLyQuaGioViewModel
    {
        public long ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<int> SoGio { get; set; }
        public string PhanLoai { get; set; }

     
    }
}