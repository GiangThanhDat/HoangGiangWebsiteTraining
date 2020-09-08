﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Platform.Web.Models
{
    public class HopDongMuaViewModel
    {
        public string MaHopDongMua { get; set; }
        public string TrichYeu { get; set; }
        public string MaNhaCungCap { get; set; }
        public Nullable<int> MaLoaiTien { get; set; }
        public Nullable<double> TyGia { get; set; }
        public string GiaTriHopDong { get; set; }
        public string NguoiLienHe { get; set; }
        public string GiaTriHopDongQuyDoi { get; set; }
        public Nullable<System.DateTime> HanGiaoHang { get; set; }
        public Nullable<int> MaTinhTrang { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public string GiaTriThanhLy { get; set; }
        public string GiaTriThanhLyQuyDoi { get; set; }
        public Nullable<System.DateTime> HanThanhToan { get; set; }
        public string NgayThanhLy_HuyBo { get; set; }
        public string MaSoNhanVien { get; set; }
        public string LyDo { get; set; }
        public string DieuKhoanKhac { get; set; }
        public Nullable<bool> LaHopDongPhatSinh { get; set; }
        public Nullable<double> TienChietKhau { get; set; }
        public Nullable<double> TienThueGTGT { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
        public Nullable<System.DateTime> NgayKy { get; set; }

    }
}