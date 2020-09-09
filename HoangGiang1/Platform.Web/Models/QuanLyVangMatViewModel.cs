using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class QuanLyVangMatViewModel
    {
        public long ID { get; set; }
        public string MaSoNhanVien { get; set; }
        public DateTime NgayVangMat { get; set; }
        public string GioVao { get; set; }
        public string GioRa { get; set; }
        public string TrangThai { get; set; }

    }
}