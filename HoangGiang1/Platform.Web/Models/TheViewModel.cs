using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class TheViewModel
    {
        public long ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public string MaThe { get; set; }
        public string LoaiThe { get; set; }
        public Nullable<System.DateTime> NgayYeuCau { get; set; }
        public Nullable<System.DateTime> NgayCap { get; set; }
        public Nullable<System.DateTime> NgayHetHan { get; set; }
        public string TrangThai { get; set; }
    }
}