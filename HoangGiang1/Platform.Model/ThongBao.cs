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

    [Table("ThongBao")]

    public partial class ThongBao
    {
        [Key]
        public long MaSoTB { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string GhiChu { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<System.DateTime> NgayThongBao { get; set; }
        public Nullable<bool> DaXoa { get; set; }
        public string NguoiXoa { get; set; }
        public Nullable<System.DateTime> ThoiGianXoa { get; set; }
    }
}