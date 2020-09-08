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
    public interface IPhieuNhapKhoService
    {
        void Add(PhieuNhapKho phieuNhapKho);
        void Update(PhieuNhapKho phieuNhapKho);
        void delete(int id);
        IEnumerable<PhieuNhapKho> GetAll();
        PhieuNhapKho GetByID(int id);
        IQueryable<getphieunhapxuatkho> getphieunhapxuatkho(DateTime ngaydau, DateTime ngaycuoi);
        IEnumerable<lichsutongquan> getlichsu();

        void Commit();
        void Save();

    }
    public class PhieuNhapKhoService : IPhieuNhapKhoService
    {
        IPhieuNhapKhoRepository _phieuNhapKhoRepository;
        IUnitOfWork _unitOfWork;
        public PhieuNhapKhoService(IPhieuNhapKhoRepository phieuNhapKhoRepository, IUnitOfWork unitOfWork)
        {
            this._phieuNhapKhoRepository = phieuNhapKhoRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(PhieuNhapKho phieuNhapKho)
        {
            _phieuNhapKhoRepository.Add(phieuNhapKho);
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
            _phieuNhapKhoRepository.Delete(id);
        }

        public IEnumerable<PhieuNhapKho> GetAll()
        {
            return _phieuNhapKhoRepository.GetAll();
        }

        public PhieuNhapKho GetByID(int id)
        {
            return _phieuNhapKhoRepository.GetSingleById(id);
        }

       

        public void Update(PhieuNhapKho phieuNhapKho)
        {
            _phieuNhapKhoRepository.Update(phieuNhapKho);
        }

        public IQueryable<getphieunhapxuatkho> getphieunhapxuatkho(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _phieuNhapKhoRepository.getphieunhapxuatkho(ngaydau, ngaycuoi);
        }

        public IEnumerable<lichsutongquan> getlichsu()
        {
            return _phieuNhapKhoRepository.getlichsu();
        }
    }
}
