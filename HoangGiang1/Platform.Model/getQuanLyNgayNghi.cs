using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Model
{
  public  class getQuanLyNgayNghi
    {
        public string MaSoNhanVien { get; set; }
        public string GioBatDau { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public string GioKetThuc { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public string LoaiNghi { get; set; }
        public Nullable<int> TongGio { get; set; }
        public Nullable<int> TongNgayLamViecNghi { get; set; }
        public Nullable<int> TongNgayNghi { get; set; }

        public string MaCoSo { get; set; }
        public string TenCoSo { get; set; }
        public string HoVaTen { get; set; }

    }
}
