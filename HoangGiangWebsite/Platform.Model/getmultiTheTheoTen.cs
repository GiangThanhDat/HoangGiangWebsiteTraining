using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public  class getMultiTheTheoTen
    {
        public long ID { get; set; }
        public string MaSoNhanVien { get; set; }
       
        public string MaThe { get; set; }
        public string LoaiThe { get; set; }
        public Nullable<System.DateTime> NgayYeuCau { get; set; }
        public Nullable<System.DateTime> NgayCap { get; set; }
        public Nullable<System.DateTime> NgayHetHan { get; set; }
        public string TrangThai { get; set; }
        public string HoVaTen { get; set; }
    }
}
