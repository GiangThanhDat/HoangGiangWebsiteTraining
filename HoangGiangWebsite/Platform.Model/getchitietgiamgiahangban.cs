using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Model
{
  public  class getchitietgiamgiahangban
    {
        public string MaGiamGiaHangBan { get; set; }
        public string MaChungTuBanHang { get; set; }
        public string MaHang { get; set; }
       
        public string TKGiamGia { get; set; }
        public string TKTien { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> ChietKhau { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public Nullable<double> VAT { get; set; }

        public string TenHang { get; set; }

        public Nullable<double> GiaKhuyenMai { get; set; }
        public string DonViTinh { get; set; }

    }
}
