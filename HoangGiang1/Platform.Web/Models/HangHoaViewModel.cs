using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class HangHoaViewModel
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public int MaNhomHH { get; set; }
        public int MaTinhChat { get; set; }
        public string DonViTinh { get; set; }
        public string BaoHanh { get; set; }
        public string NguonGoc { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> GiaNhap { get; set; }
        public Nullable<int> GiaBan { get; set; }
        public Nullable<int> GiaKhuyenMai { get; set; }
        public Nullable<double> VAT { get; set; }
        public Nullable<double> ChietKhau { get; set; }
        public string HanSuDung { get; set; }
        public string ThanhPham { get; set; }
        public string SoLo { get; set; }
        public string HinhAnh { get; set; }
        public string NguoiSua { get; set; }
        public Nullable<System.DateTime> NgaySua { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public string NguoiNhap { get; set; }

        public TinhChatHangHoaViewModel TinhChatHangHoa { get; set; }
        public NhomHangHoaViewModel NhomHangHoa { get; set; }
        public DonViTinhViewModel DonViTinhs { get; set; }
        public IEnumerable<getdvt> getdvt { get; set; }


    }
}