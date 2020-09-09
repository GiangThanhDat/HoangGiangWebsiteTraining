using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class QuanLyCongTacViewModel
    {
        public long ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public string GioBatDau { get; set; }
        public DateTime NgayBatDau { get; set; }
        public string GioKetThuc { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public Nullable<int> TongGio { get; set; }
        public Nullable<int> TongNgayLamViec { get; set; }
        public Nullable<int> TongNgay { get; set; }
        public string DiaDiem { get; set; }
        public string NoiDung { get; set; }

    }
}