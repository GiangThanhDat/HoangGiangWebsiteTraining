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

    [Table("ChiTietTraLaiHangBan")]

    public partial class ChiTietTraLaiHangBan
    {
        [Key]
        public int MaChiTietTraLaiHangBan { get; set; }
        public string MaTraLaiHangBan { get; set; }
        public string MaHang { get; set; }
        public string TKTraLai { get; set; }
        public string TKTien { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public string MucThuChi { get; set; }

        public virtual HangHoa HangHoa { get; set; }
        public virtual TraLaiHangBan TraLaiHangBan { get; set; }
    }
}
