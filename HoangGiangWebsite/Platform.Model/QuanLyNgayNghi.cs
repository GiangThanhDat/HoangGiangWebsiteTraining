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

    [Table("QuanLyNgayNghi")]
    public partial class QuanLyNgayNghi
    {
        [Key]
        public long ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public string GioBatDau { get; set; }
        public DateTime NgayBatDau { get; set; }
        public string GioKetThuc { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public string LoaiNghi { get; set; }
        public Nullable<int> TongGio { get; set; }
        public Nullable<int> TongNgayLamViecNghi { get; set; }
        public Nullable<int> TongNgayNghi { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}
