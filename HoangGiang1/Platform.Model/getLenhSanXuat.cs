using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Model
{
  public  class getLenhSanXuat
    {
        public string MaLenhSanXuat { get; set; }
        public string DienGiai { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public Nullable<int> MaTinhTrang { get; set; }
        public string TenTinhTrang { get; set; }
        public Nullable<bool> DaGhiSo { get; set; }
    }
}
