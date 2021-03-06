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

    [Table("PhieuXuatKho")]
    public partial class PhieuXuat_BanHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuXuat_BanHang()
        {
            this.ChiTietPhieuXuat_BanHang = new HashSet<ChiTietPhieuXuat_BanHang>();
        }
        [Key]
        public string MaPhieuXuat { get; set; }
        public string MaKhachHang { get; set; }
        public string NguoiNhan { get; set; }
        public string LyDoXuat { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<int> ChungTuGoc { get; set; }
        public Nullable<System.DateTime> NgayHoachToan { get; set; }
        public Nullable<System.DateTime> NgayChungTu { get; set; }
        public Nullable<int> MaDieuKhoan { get; set; }
        public Nullable<double> SoNgayDuocNo { get; set; }
        public Nullable<System.DateTime> HanThanhToan { get; set; }
        public Nullable<int> MaLoaiTien { get; set; }
        public Nullable<double> TyGia { get; set; }
        public Nullable<double> TongTienHang { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
        public string MaChungTuBanHang { get; set; }
        public string MaTraLaiHangBan { get; set; }
        public string DienGiai { get; set; }
        public Nullable<bool> DaGhiSo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuXuat_BanHang> ChiTietPhieuXuat_BanHang { get; set; }
        public virtual DieuKhoanTT DieuKhoanThanhToan { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual LoaiTien LoaiTien { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual ChungTuBanHang ChungTuBanHang { get; set; }
       

    }
}
