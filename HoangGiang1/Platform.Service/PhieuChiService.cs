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
    public interface IPhieuChiService
    {
        void Add(PhieuChi phieuChi);
        void Update(PhieuChi phieuChi);
        void delete(int id);
        IEnumerable<PhieuChi> GetAll();
        PhieuChi GetByID(int id);
        IQueryable<getThongTinTongHopQuy> getPhieuChi(DateTime ngaydau, DateTime ngaycuoi);
        IEnumerable<xemchitietphieuchi> xemPhieuChi(string MaPC);

        void Commit();
        void Save();

    }
    public class PhieuChiService : IPhieuChiService
    {
        IPhieuChiRepository _phieuChiRepository;
        IUnitOfWork _unitOfWork;
        public PhieuChiService(IPhieuChiRepository phieuChiRepository, IUnitOfWork unitOfWork)
        {
            this._phieuChiRepository = phieuChiRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(PhieuChi phieuChi)
        {
            _phieuChiRepository.Add(phieuChi);
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
            _phieuChiRepository.Delete(id);
        }

        public IEnumerable<PhieuChi> GetAll()
        {
            return _phieuChiRepository.GetAll();
        }

        public PhieuChi GetByID(int id)
        {
            return _phieuChiRepository.GetSingleById(id);
        }

       

        public void Update(PhieuChi phieuChi)
        {
            _phieuChiRepository.Update(phieuChi);
        }

        public IQueryable<getThongTinTongHopQuy> getPhieuChi(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _phieuChiRepository.getPhieuChi(ngaydau, ngaycuoi);
        }

       

        public IEnumerable<xemchitietphieuchi> xemPhieuChi(string MaPC)
        {
            return _phieuChiRepository.xemPhieuChi(MaPC);
        }
    }
}
