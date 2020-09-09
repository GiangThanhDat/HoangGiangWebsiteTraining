using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class NhaCungCap_TaiKhoanViewModel
    {
        public int id { get; set; }

        public string MaNhaCungCap { get; set; }
        public string MaTaiKhoan { get; set; }
        public string GhiChu { get; set; }
    }
}