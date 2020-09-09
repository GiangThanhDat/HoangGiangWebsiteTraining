using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Model
{
   public class getlenhlaprapthaodo
    {
        public Nullable<System.DateTime> Ngay { get; set; }
        public string MaLapRapThaoDo { get; set; }
        public string MaThanhPham { get; set; }
        public string TenThanhPham { get; set; }


        public string DienGiai { get; set; }
        public string DonViTinh { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> GiaKhuyenMai { get; set; }
        public Nullable<double> ThanhTien { get; set; }
    }

}
