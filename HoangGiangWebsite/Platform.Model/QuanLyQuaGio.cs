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

    [Table("QuanLyQuaGio")]
    public partial class QuanLyQuaGio
    {
        [Key]
        public long ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public Nullable<int> SoGio { get; set; }
        public string PhanLoai { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}