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

    [Table("KhachHang_TaiKhoan")]
    public partial class KhachHang_TaiKhoan
    {   
        [Key]
        public int id { get; set; }
        public string MaKhachHang { get; set; }
        public string MaTaiKhoan { get; set; }
        public string GhiChu { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        public virtual TaiKhoanNganHang TaiKhoanNganHang { get; set; }
    }
}