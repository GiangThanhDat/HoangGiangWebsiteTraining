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

    [Table("Loi")]

    public partial class Loi
    {
        [Key]
        public int MaLoi { get; set; }
        public string ThongBao { get; set; }
        public Nullable<System.DateTime> NgayGio { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> DaXoa { get; set; }
        public string NguoiXoa { get; set; }
        public Nullable<System.DateTime> ThoiGianXoa { get; set; }
    }
}