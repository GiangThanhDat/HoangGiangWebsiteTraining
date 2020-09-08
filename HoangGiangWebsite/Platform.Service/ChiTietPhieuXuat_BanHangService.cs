using Platform.Data.Infrastructure;
using Platform.Data.Repositories;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface IChiTietPhieuXuat_BanHangService
    {
        void Add(ChiTietPhieuXuat_BanHang chiTietPhieuXuat_BanHang);
        void Update(ChiTietPhieuXuat_BanHang chiTietPhieuXuat_BanHang);
        void delete(int id);
        IEnumerable<ChiTietPhieuXuat_BanHang> GetAll();
        ChiTietPhieuXuat_BanHang GetByID(int id);
        IQueryable<chitietxuatnhapkho> getchitietxuatnhapkho(string MaPhieuXuat);
        void Commit();
        void Save();

    }
    public class ChiTietPhieuXuat_BanHangService : IChiTietPhieuXuat_BanHangService
    {
        IChiTietPhieuXuat_BanHangRepository _chiTietPhieuXuat_BanHangRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietPhieuXuat_BanHangService(IChiTietPhieuXuat_BanHangRepository chiTietPhieuXuat_BanHangRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietPhieuXuat_BanHangRepository = chiTietPhieuXuat_BanHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietPhieuXuat_BanHang chiTietPhieuXuat_BanHang)
        {
            _chiTietPhieuXuat_BanHangRepository.Add(chiTietPhieuXuat_BanHang);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
        public void Commit()
        {
            _unitOfWork.Commit();
        }
		 

        public void delete(int id)
        {
            _chiTietPhieuXuat_BanHangRepository.Delete(id);
        }

        public IEnumerable<ChiTietPhieuXuat_BanHang> GetAll()
        {
            return _chiTietPhieuXuat_BanHangRepository.GetAll();
        }

        public ChiTietPhieuXuat_BanHang GetByID(int id)
        {
            return _chiTietPhieuXuat_BanHangRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietPhieuXuat_BanHang chiTietPhieuXuat_BanHang)
        {
            _chiTietPhieuXuat_BanHangRepository.Update(chiTietPhieuXuat_BanHang);
        }

        public IQueryable<chitietxuatnhapkho> getchitietxuatnhapkho(string MaPhieuXuat)
        {
            return _chiTietPhieuXuat_BanHangRepository.getchitietxuatnhapkho(MaPhieuXuat);
        }
    }
}
