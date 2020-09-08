using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class LoiViewModel
    {
        public int MaLoi { get; set; }
        public string ThongBao { get; set; }
        public Nullable<System.DateTime> NgayGio { get; set; }
        public string GhiChu { get; set; }
    }
}