
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class LenhSanXuat_ThanhPhamViewModel
    {
        public int MaLenhSanXuat_ThanhPham { get; set; }
        public string MaLenhSanXuat { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string MaThanhPham { get; set; }
    }
}