using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class QuanLyNgayNghiViewModel
    {
        public long ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public string GioBatDau { get; set; }
        public DateTime NgayBatDau { get; set; }
        public string GioKetThuc { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public string LoaiNghi { get; set; }
        public Nullable<int> TongGio { get; set; }
        public Nullable<int> TongNgayLamViecNghi { get; set; }
        public Nullable<int> TongNgayNghi { get; set; }
    }
}