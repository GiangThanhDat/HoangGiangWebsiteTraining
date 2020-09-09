using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class LichSuLamViecViewModel
    {
        public long ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public string TenCongTy { get; set; }
        public string ViTriLamViec { get; set; }
        public string NoiDungCongViec { get; set; }

    }
}