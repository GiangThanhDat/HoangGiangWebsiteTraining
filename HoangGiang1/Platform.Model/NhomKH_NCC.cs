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

    [Table("NhomKH_NCC")]
    public partial class NhomKH_NCC1
    {
        [Key]
        public string NhomKH_NCC { get; set; }
        public string TenNhomKH_NCC { get; set; }
        public string DienGiai { get; set; }

        public virtual ICollection<KhachHang> KhachHang { get; set; }
        public virtual ICollection<NhaCungCap> NhaCungCap { get; set; }

    }
}
