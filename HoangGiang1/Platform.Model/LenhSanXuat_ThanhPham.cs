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

    [Table("LenhSanXuat_ThanhPham")]
    public partial class LenhSanXuat_ThanhPham
    {
        [Key]
        public int MaLenhSanXuat_ThanhPham { get; set; }
        public string MaLenhSanXuat { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string MaThanhPham { get; set; }
    
        public virtual LenhSanXuat LenhSanXuat { get; set; }
        public virtual ThanhPham ThanhPham { get; set; }
    }
}