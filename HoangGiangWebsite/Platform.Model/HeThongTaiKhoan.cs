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

    [Table("HeThongTaiKhoan")]
    public partial class HeThongTaiKhoan
    {
        [Key]
        public int Id { get; set; }
        public string SoTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string TinhChat { get; set; }
        public string TenTiengAnh { get; set; }
        public string DienGiai { get; set; }
        public Nullable<bool> NgungTheoDoi { get; set; }
    }
}
