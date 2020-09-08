using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Model
{
  public  class getchitietdondathang
    {

        public string MaHang { get; set; }
        public string TenHang { get; set; }
      
        public string DonViTinh { get; set; }
        public Nullable<double> GiaKhuyenMai { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
      
        public Nullable<double> VAT { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public Nullable<double> ThanhTien { get; set; }


        public Nullable<int> SoLuong { get; set; }
        public string MaDonDatHang { get; set; }

    }
}
