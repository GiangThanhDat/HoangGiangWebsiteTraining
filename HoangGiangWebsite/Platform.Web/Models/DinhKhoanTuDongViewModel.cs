using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class DinhKhoanTuDongViewModel
    {
        public int Id { get; set; }
        public string LoaiChungTu { get; set; }
        public string TenDinhKhoan { get; set; }
        public string SoTaiKhoanCo { get; set; }
        public string SoTaiKhoanNo { get; set; }
    }
}