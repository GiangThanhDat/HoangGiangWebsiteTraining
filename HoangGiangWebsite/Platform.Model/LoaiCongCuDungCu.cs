﻿//------------------------------------------------------------------------------
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

    [Table("LoaiCongCuDungCu")]
    public partial class LoaiCongCuDungCu
    {
        [Key]
        public string MaLoaiCCDC { get; set; }
        public string TenLoaiCCDC { get; set; }
        public string DienGiai { get; set; }
        public string SoTaiKhoanCo { get; set; }
       


      
    }
}
