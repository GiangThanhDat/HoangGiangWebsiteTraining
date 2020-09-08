
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class LenhSanXuatViewModel
    {
        public string MaLenhSanXuat { get; set; }
        public string DienGiai { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public Nullable<int> MaTinhTrang { get; set; }
        public Nullable<bool> DaGhiSo { get; set; }

    }
}