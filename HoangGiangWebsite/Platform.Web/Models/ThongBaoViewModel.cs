using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ThongBaoViewModel
    {
        public long MaSoTB { get; set; }
        public string NoiDung { get; set; }
        public Nullable<System.DateTime> NgayThongBao { get; set; }
    }
}