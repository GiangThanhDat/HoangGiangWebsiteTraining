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

    [Table("TaiSan")]
    public partial class TaiSan
    {

         [Key]
        public string MaTaiSan { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<System.DateTime> NgayBatDauSuDung { get; set; }
        public Nullable<System.DateTime> NgayHetHan { get; set; }
        public string MaCoSo { get; set; }
        public string KieuTaiSan { get; set; }
        public string MoTaChiTiet { get; set; }
        public string TinhTrang { get; set; }
        public Nullable<System.DateTime> NgayNhapLieu { get; set; }
        public string NguoiNhap { get; set; }
    
        public virtual CoSo CoSo { get; set; }
      
        public virtual ICollection<QuanLyTaiSan> QuanLyTaiSans { get; set; }
    }
}