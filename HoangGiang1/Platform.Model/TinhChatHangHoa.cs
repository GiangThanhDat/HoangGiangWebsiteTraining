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

    [Table("TinhChatHangHoa")]
    public partial class TinhChatHangHoa
    {
         
        [Key]
        public int MaTinhChat { get; set; }
        public string TenTinhChat { get; set; }
        public string GhiChu { get; set; }
    
        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
