using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class TaiKhoanKetChuyenViewModel
    {
        public int Id { get; set; }
        public Nullable<int> ThuTuKetChuyen { get; set; }
        public string MaKetChuyen { get; set; }
        public string KetChuyenTu { get; set; }
        public string KetChuyenDen { get; set; }
        public string BenKetChuyen { get; set; }
        public string DienGiai { get; set; }
        public string LoaiKetChuyen { get; set; }
        public Nullable<bool> NgungTheoDoi { get; set; }
    }
}