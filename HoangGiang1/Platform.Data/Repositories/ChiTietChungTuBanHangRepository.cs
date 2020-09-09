using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietChungTuBanHangRepository : IRepository<ChiTietChungTuBanHang>
    {

        IQueryable<getchitietchungtubanhang> getchitietchungtubanhang(string MaChungTuBanHang);
        IEnumerable<thongketop10> thongkechitietchungtubanhang(DateTime ngaydau, DateTime ngaycuoi, bool dathaydoi);

    }

    class ChiTietChungTuBanHangRepository : RepositoryBase<ChiTietChungTuBanHang>, IChiTietChungTuBanHangRepository
    {
        public ChiTietChungTuBanHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getchitietchungtubanhang> getchitietchungtubanhang(string MaChungTuBanHang)
        {
            var query = from A in DbContext.chungTuBanHangs
                        join B in DbContext.chiTietChungTuBanHangs
                        on A.MaChungTuBanHang equals B.MaChungTuBanHang
                        join C in DbContext.hangHoas
                        on B.MaHang equals C.MaHang

                        where B.MaChungTuBanHang.Equals(MaChungTuBanHang)
                        select new getchitietchungtubanhang()
                        {
                            MaHang = C.MaHang,
                            TenHang = C.TenHang,
                            TKCongNo_ChiPhi=B.TKCongNo_ChiPhi,
                            TKDoanhThu=B.TKDoanhThu,

                            DonViTinh = C.DonViTinh,
                            SoLuong = B.SoLuong,
                            GiaKhuyenMai = C.GiaKhuyenMai,
                            ThanhTien=B.ThanhTien,
                            ChietKhau=C.ChietKhau,
                            TienChietKhau=B.TienChietKhau,
                            VAT = C.VAT,
                            TienThueGTGT = A.TienThueGTGT,
                            MaDonViTinh=B.MaDonViTinh






                        };
            return query;
        }

        public IEnumerable<thongketop10> thongkechitietchungtubanhang(DateTime ngaydau, DateTime ngaycuoi, bool dathaydoi)
        {
            var query = from a in DbContext.chungTuBanHangs
                        join b in DbContext.chiTietChungTuBanHangs
                        on a.MaChungTuBanHang equals b.MaChungTuBanHang
                        join c in DbContext.hangHoas
                        on b.MaHang equals c.MaHang
                        join d in DbContext.donViTinhs
                        on b.MaDonViTinh equals d.MaDonViTinh
                        join e in DbContext.NhanVien
                        on a.MaSoNhanVien equals e.MaSoNhanVien
                        join f in DbContext.CoSo
                        on e.MaCoSo equals f.MaCoSo
                        where ngaydau <= a.NgayChungTu && a.NgayChungTu <= ngaycuoi && a.DaThayDoi == dathaydoi

                        select new thongketop10()
                        {
                            TenHang = c.TenHang,
                            ThanhTien = b.ThanhTien,
                            TenDonViTinh = d.TenDonViTinh,
                            SoLuong = b.SoLuong,
                            MaHang=c.MaHang,
                            MaSoNhanVien=a.MaSoNhanVien,
                            HoVaTen=e.HoVaTen,
                            MaCoSo=f.MaCoSo,
                            TenCoSo=f.TenCoSo
                        };
           
            return  query;
        }

      
    }
}
