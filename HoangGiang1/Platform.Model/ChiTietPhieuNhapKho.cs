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

    [Table("ChiTietPhieuNhapKho")]
    public partial class ChiTietPhieuNhapKho
    {
        [Key]
        public int MaChiTietPhieuNhapKho { get; set; }
        public string MaPhieuNhapKho { get; set; }
        public string MaHang { get; set; }
        public string Kho { get; set; }
        public string TKNo { get; set; }
        public string TKCo { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public string MaLenhSanXuat { get; set; }
    
        public virtual HangHoa HangHoa { get; set; }
        public virtual PhieuNhapKho PhieuNhapKho { get; set; }
    }
}