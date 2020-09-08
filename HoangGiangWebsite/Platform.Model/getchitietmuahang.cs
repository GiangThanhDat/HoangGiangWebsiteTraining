using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Model
{
 public   class getchitietmuahang
    {

        public int MaCTDMH { get; set; }
        public string MaDonMuaHang { get; set; }
        public string MaHang { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> SoLuongNhan { get; set; }
        public Nullable<double> DonGia { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<double> ThueGTGT { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public string LenhSanXuat { get; set; }
        public string ThanhPham { get; set; }
    }
}
