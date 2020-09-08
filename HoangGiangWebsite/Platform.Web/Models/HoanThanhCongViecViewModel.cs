using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class HoanThanhCongViecViewModel
    {
        public long ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public string LoaiDanhGia { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public string XepLoai { get; set; }
    }
}