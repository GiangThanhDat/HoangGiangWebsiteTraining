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
    public interface IPhieuThuService
    {
        void Add(PhieuThu phieuThu);
        void Update(PhieuThu phieuThu);
        void delete(int id);
        IEnumerable<PhieuThu> GetAll();
        PhieuThu GetByID(int id);
        IQueryable<getThongTinTongHopQuy> getPhieuThu(DateTime ngaydau, DateTime ngaycuoi);
        IQueryable<getchitietphieuthu> getchitietphieuthu(string maPT);

        void Commit();
        void Save();

    }
    public class PhieuThuService : IPhieuThuService
    {
        IPhieuThuRepository _phieuThuRepository;
        IUnitOfWork _unitOfWork;
        public PhieuThuService(IPhieuThuRepository phieuThuRepository, IUnitOfWork unitOfWork)
        {
            this._phieuThuRepository = phieuThuRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(PhieuThu phieuThu)
        {
            _phieuThuRepository.Add(phieuThu);
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
            _phieuThuRepository.Delete(id);
        }

        public IEnumerable<PhieuThu> GetAll()
        {
            return _phieuThuRepository.GetAll();
        }

        public PhieuThu GetByID(int id)
        {
            return _phieuThuRepository.GetSingleById(id);
        }

       

        public void Update(PhieuThu phieuThu)
        {
            _phieuThuRepository.Update(phieuThu);
        }

        public IQueryable<getThongTinTongHopQuy> getPhieuThu(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _phieuThuRepository.getPhieuThu(ngaydau, ngaycuoi);
        }
        public IQueryable<getchitietphieuthu> getchitietphieuthu(string maPT)
        {
            return _phieuThuRepository.getchitietphieuthu(maPT);
        }
    }
}
