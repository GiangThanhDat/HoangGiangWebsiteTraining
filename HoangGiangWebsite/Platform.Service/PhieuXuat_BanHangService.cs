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
    public interface IPhieuXuat_BanHangService
    {
        void Add(PhieuXuat_BanHang phieuXuat_BanHang);
        void Update(PhieuXuat_BanHang phieuXuat_BanHang);
        void delete(int id);
        IEnumerable<PhieuXuat_BanHang> GetAll();
        PhieuXuat_BanHang GetByID(int id);
        IQueryable<getphieunhapxuatkho> getphieunhapxuatkho(DateTime ngaydau, DateTime ngaycuoi);

        void Commit();
        void Save();

    }
    public class PhieuXuat_BanHangService : IPhieuXuat_BanHangService
    {
        IPhieuXuat_BanHangRepository _phieuXuat_BanHangRepository;
        IUnitOfWork _unitOfWork;
        public PhieuXuat_BanHangService(IPhieuXuat_BanHangRepository phieuXuat_BanHangRepository, IUnitOfWork unitOfWork)
        {
            this._phieuXuat_BanHangRepository = phieuXuat_BanHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(PhieuXuat_BanHang phieuXuat_BanHang)
        {
            _phieuXuat_BanHangRepository.Add(phieuXuat_BanHang);
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
            _phieuXuat_BanHangRepository.Delete(id);
        }

        public IEnumerable<PhieuXuat_BanHang> GetAll()
        {
            return _phieuXuat_BanHangRepository.GetAll();
        }

        public PhieuXuat_BanHang GetByID(int id)
        {
            return _phieuXuat_BanHangRepository.GetSingleById(id);
        }

       

        public void Update(PhieuXuat_BanHang phieuXuat_BanHang)
        {
            _phieuXuat_BanHangRepository.Update(phieuXuat_BanHang);
        }

        public IQueryable<getphieunhapxuatkho> getphieunhapxuatkho(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _phieuXuat_BanHangRepository.getphieunhapxuatkho(ngaydau, ngaycuoi);
        }
    }
}
