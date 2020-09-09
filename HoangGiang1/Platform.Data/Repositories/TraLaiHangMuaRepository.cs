using Platform.Data.Infrastructure;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Repositories
{
    public interface ITraLaiHangMuaRepository : IRepository<TraLaiHangMua>
    {
        IQueryable<gettralaihangmua> gettralaihangmua(DateTime ngaydau, DateTime ngaycuoi);

    }

    class TraLaiHangMuaRepository : RepositoryBase<TraLaiHangMua>, ITraLaiHangMuaRepository
    {
        public TraLaiHangMuaRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<gettralaihangmua> gettralaihangmua(DateTime ngaydau, DateTime ngaycuoi)
        {
            var query = from A in DbContext.traLaiHangMuas
                        join B in DbContext.nhaCungCaps
                        on A.MaNhaCungCap equals B.MaNhaCungCap
                      
                        join D in DbContext.loaiTiens
                        on A.MaLoaiTien equals D.MaLoaiTien
                      
                        join R in DbContext.NhanVien
                        on A.MaSoNhanVien equals R.MaSoNhanVien

                        where ngaydau <= A.NgayChungTu && A.NgayChungTu <= ngaycuoi
                        select new gettralaihangmua()
                        {
                          
                            MaTraLaiHangMua = A.MaTraLaiHangMua,
                            MaNhaCungCap = A.MaNhaCungCap,
                           TenNhaCungCap=B.TenNhaCungCap,
                         NguoiNhanHang=A.NguoiNhanHang,
                           DienGiai=A.DienGiai,
                           ChungTuGoc=A.ChungTuGoc,
                           TenLoaiTien=D.TenLoaiTien,
                           TyGia=A.TyGia,
                           NgayHoachToan=A.NgayHoachToan,
                           NgayChungTu=A.NgayChungTu,
                           TongTienHang=A.TongTienHang,
                           TienThueGTGT=A.TienThueGTGT,
                           TongTienThanhToan=A.TongTienThanhToan
                           ,
                           MaSoThue=B.MaSoThue,
                           DiaChi=B.DiaChi,
                          HoVaTen=R.HoVaTen,
                          VietTat=D.VietTat,
                          DaGhiSo=A.DaGhiSo







                        };


            return query;
        }
    }
}
