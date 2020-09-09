using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class HeThongTaiKhoanViewModel
    {
        public int Id { get; set; }
        public string SoTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string TinhChat { get; set; }
        public string TenTiengAnh { get; set; }
        public string DienGiai { get; set; }
        public Nullable<bool> NgungTheoDoi { get; set; }
    }
}