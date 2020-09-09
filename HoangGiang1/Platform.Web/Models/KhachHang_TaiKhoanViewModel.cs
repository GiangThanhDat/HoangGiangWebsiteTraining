using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class KhachHang_TaiKhoanViewModel
    {
        public int id { get; set; }
        public string MaKhachHang { get; set; }
        public string MaTaiKhoan { get; set; }
        public string GhiChu { get; set; }
    }
}