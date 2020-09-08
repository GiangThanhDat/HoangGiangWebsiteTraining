using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietPhieuNhapKhoRepository : IRepository<ChiTietPhieuNhapKho>
    {
        IQueryable<chitietxuatnhapkho> getchitietxuatnhapkho(string MaPhieuNhapKho);


    }

    class ChiTietPhieuNhapKhoRepository : RepositoryBase<ChiTietPhieuNhapKho>, IChiTietPhieuNhapKhoRepository
    {
        public ChiTietPhieuNhapKhoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<chitietxuatnhapkho> getchitietxuatnhapkho(string MaPhieuNhapKho)
        {
            var query = from A in DbContext.phieuNhapKhos
                        join B in DbContext.chiTietPhieuNhapKhos
                        on A.MaPhieuNhapKho equals B.MaPhieuNhapKho
                        join C in DbContext.hangHoas
                        on B.MaHang equals C.MaHang

                        where B.MaPhieuNhapKho.Equals(MaPhieuNhapKho)
                        select new chitietxuatnhapkho()
                        {
                            MaHang = C.MaHang,
                            TenHang = C.TenHang,
                            Kho=B.Kho,
                            TKCo=B.TKCo,
                            TKNo=B.TKNo,
                            DonViTinh = C.DonViTinh,
                            GiaKhuyenMai = C.GiaKhuyenMai,


                            ////SoLuong = B.SoLuong,

                            //ThanhTien = B.ThanhTien,
                           
                            ////TienChietKhau = B.TienChietKhau,
                            //VAT = C.VAT,
                          





                        };
            return query;
        }
    }
}
