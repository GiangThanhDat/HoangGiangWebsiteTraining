using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class QuetTheViewModel
    {
        public long ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public string GioQuetThe { get; set; }
        public Nullable<System.DateTime> NgayQuetThe { get; set; }

    }
}