//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Platform.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChiTietPhieuChi")]
    public partial class ChiTietPhieuChi
    {
        [Key]
        public int MaCTPC { get; set; }
        public string MaPhieuChi { get; set; }
        public string MaHang { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> SoTien { get; set; }
        public string DienGiai { get; set; }
        public string SoTaiKhoanCo { get; set; }
        public string SoTaiKhoanNo { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string TaiKhoanNganHang { get; set; }
        public string MucThuChi { get; set; }
        public string DonVi { get; set; }
        public string CongTrinh { get; set; }
        public string HopDongBan { get; set; }
        public string MaThongKe { get; set; }
        public string KhoanMucCP { get; set; }
        public string DoiTuongDHCP { get; set; }
        public string DonDatHang { get; set; }
        public string DonMuaHang { get; set; }

        public virtual HangHoa HangHoa { get; set; }
        public virtual PhieuChi PhieuChi { get; set; }
    }
}
