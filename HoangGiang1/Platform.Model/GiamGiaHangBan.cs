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

    [Table("GiamGiaHangBan")]
    public partial class GiamGiaHangBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiamGiaHangBan()
        {
            this.ChiTietGiamGiaHangBans = new HashSet<ChiTietGiamGiaHangBan>();
        }
        [Key]
        public string MaGiamGiaHangBan { get; set; }
        public string MaKhachHang { get; set; }
        public string DienGiai { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<System.DateTime> NgayHoachToan { get; set; }
        public Nullable<System.DateTime> NgayChungTu { get; set; }
        public Nullable<double> TongTienHang { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
        public int MaLoaiTien { get; set; }
        public Nullable<double> TyGia { get; set; }
        public Nullable<bool> DaGhiSo { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGiamGiaHangBan> ChiTietGiamGiaHangBans { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual LoaiTien LoaiTien { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}