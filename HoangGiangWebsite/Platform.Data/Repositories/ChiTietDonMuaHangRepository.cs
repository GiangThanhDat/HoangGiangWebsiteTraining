using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface IChiTietDonMuaHangRepository : IRepository<ChiTietDonMuaHang>
    {
        IQueryable<getchitietmuahang> getchitiet(string maMH);
    
    }

    class ChiTietDonMuaHangRepository : RepositoryBase<ChiTietDonMuaHang>, IChiTietDonMuaHangRepository
    {
        public ChiTietDonMuaHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<getchitietmuahang> getchitiet(string maMH)
        {
            var query = from A in DbContext.chiTietDonMuaHangs
                        join B in DbContext.donMuaHangs
                        on A.MaDonMuaHang equals B.MaDonMuaHang
                        where A.MaDonMuaHang.Equals(maMH)
                        select new getchitietmuahang {
                         MaDonMuaHang =A.MaDonMuaHang,
                         MaHang =A.MaHang,
                         SoLuong =A.SoLuong,
                        SoLuongNhan =A.SoLuongNhan,
                        DonGia= A.DonGia,
                        ThanhTien =A.ThanhTien,
                        ThueGTGT= A.ThueGTGT,
                        TienThueGTGT =A.TienThueGTGT,
                        LenhSanXuat= A.LenhSanXuat,
                         ThanhPham =A.ThanhPham




    };
            return query;

        }
    }
}
