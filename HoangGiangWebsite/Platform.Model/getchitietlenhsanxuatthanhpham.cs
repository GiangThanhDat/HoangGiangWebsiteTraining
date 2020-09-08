using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Model
{
 public   class getchitietlenhsanxuatthanhpham
    {
        public int MaLenhSanXuat_ThanhPham { get; set; }
        public string MaLenhSanXuat { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string MaThanhPham { get; set; }
      
        public string TenThanhPham { get; set; }
        public string DonViTinh { get; set; }
        public string HopDongBan { get; set; }
        public string DoiTuongDHCP { get; set; }
        public string MaThongKe { get; set; }
    }
}
