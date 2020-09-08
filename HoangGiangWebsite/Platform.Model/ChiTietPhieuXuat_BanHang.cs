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

    [Table("ChiTietPhieuXuatKho")]
    public partial class ChiTietPhieuXuat_BanHang
    {
        [Key]
        public int MaChiTietPhieuXuat { get; set; }
        public string MaPhieuXuat { get; set; }
        public string MaHang { get; set; }
        public string TKCongNo_ChiPhi { get; set; }
        public string TKDoanhThu { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public string Kho { get; set; }
        public string TKNo { get; set; }
        public string TKCo { get; set; }

        public virtual HangHoa HangHoa { get; set; }
        public virtual PhieuXuat_BanHang PhieuXuat_BanHang { get; set; }
    }
}