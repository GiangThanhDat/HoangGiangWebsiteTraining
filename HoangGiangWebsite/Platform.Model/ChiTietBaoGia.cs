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

    [Table("ChiTietBaoGia")]
    public partial class ChiTietBaoGia
    {   
        [Key]
        public int MaChiTietBaoGia { get; set; }
        public string MaSoBaoGia { get; set; }
        public string MaHang { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }


        public virtual BaoGia BaoGia { get; set; }
        public virtual HangHoa HangHoa { get; set; }
    }
}
