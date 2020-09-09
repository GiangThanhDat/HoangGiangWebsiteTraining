using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class ThongTinTuyenDungViewModel
    {
        public long ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<System.DateTime> NgayTuyen { get; set; }
        public string LoaiHopDong { get; set; }
        public string DiaDiemLamViec { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public string HinhThucLuong { get; set; }
        public string SoTienLuong { get; set; }

       
    }
}