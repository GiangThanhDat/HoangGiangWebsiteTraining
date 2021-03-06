﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class TaiSanViewModel
    {
        public string MaTaiSan { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<System.DateTime> NgayBatDauSuDung { get; set; }
        public Nullable<System.DateTime> NgayHetHan { get; set; }
        public string MaCoSo { get; set; }
        public string KieuTaiSan { get; set; }
        public string MoTaChiTiet { get; set; }
        public string TinhTrang { get; set; }
        public Nullable<System.DateTime> NgayNhapLieu { get; set; }
        public string NguoiNhap { get; set; }
    }
}