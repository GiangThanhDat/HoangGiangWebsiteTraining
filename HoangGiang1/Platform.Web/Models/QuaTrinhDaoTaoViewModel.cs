using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class QuaTrinhDaoTaoViewModel
    {
        public long ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public string TenTruong { get; set; }
        public string LoaiBang { get; set; }
        public string ChuyenNganh { get; set; }
        public string XepLoai { get; set; }

    }
}