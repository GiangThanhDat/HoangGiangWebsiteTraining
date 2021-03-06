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

    [Table("DonDatHang")]
    public partial class DonDatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonDatHang()
        {
            this.ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
        }
    
        [Key]
        public string MaDonDatHang { get; set; }
        public string MaKhachHang { get; set; }
        public string NguoiNhanHang { get; set; }
        public string DienGiai { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<int> MaDieuKhoan { get; set; }
        public Nullable<double> SoNgayDuocNo { get; set; }
        public Nullable<System.DateTime> NgayDonHang { get; set; }
        public Nullable<int> MaTinhTrang { get; set; }
        public Nullable<System.DateTime> NgayGiaoHang { get; set; }
        public Nullable<int> MaLoaiTien { get; set; }
        public Nullable<double> TyGia { get; set; }
        public Nullable<double> TongTienHang { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public Nullable<double> TongChietKhau { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
        public virtual DieuKhoanTT DieuKhoanThanhToan { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual LoaiTien LoaiTien { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual TinhTrang TinhTrang { get; set; }
    }
}
