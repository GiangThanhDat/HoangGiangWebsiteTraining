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

    [Table("LenhSanXuat_NVL")]
    public partial class LenhSanXuat_NVL
    {   [Key]
        public int MaLenhSanXuat_NVL { get; set; }
        public string MaLenhSanXuat { get; set; }
        public string MaHang { get; set; }
        public Nullable<int> SoLuong_1DonVi { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string DoiTuongDHCP { get; set; }
        public string KhoanMucCP { get; set; }
        public string MaThongKe { get; set; }
    
        public virtual HangHoa HangHoa { get; set; }
        public virtual LenhSanXuat LenhSanXuat { get; set; }
    }
}