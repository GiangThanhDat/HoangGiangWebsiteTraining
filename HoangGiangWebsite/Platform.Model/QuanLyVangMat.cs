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

    [Table("QuanLyVangMat")]
    public partial class QuanLyVangMat
    {
        [Key]
        public long ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public DateTime NgayVangMat { get; set; }
        public string GioVao { get; set; }
        public string GioRa { get; set; }
        public string TrangThai { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}
