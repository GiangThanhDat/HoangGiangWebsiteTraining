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
    public interface ILenhSanXuat_NVLService
    {
        void Add(LenhSanXuat_NVL lenhSanXuat_NVL);
        void Update(LenhSanXuat_NVL lenhSanXuat_NVL);
        void delete(int id);
        IEnumerable<LenhSanXuat_NVL> GetAll();
        LenhSanXuat_NVL GetByID(int id);
        IQueryable<getlenhsanxuatNVL> getlenhsanxuatNVL(string MaLenhSanXuat);
        void Commit();
        void Save();

    }
    public class LenhSanXuat_NVLService : ILenhSanXuat_NVLService
    {
        ILenhSanXuat_NVLRepository _lenhSanXuat_NVLRepository;
        IUnitOfWork _unitOfWork;
        public LenhSanXuat_NVLService(ILenhSanXuat_NVLRepository lenhSanXuat_NVLRepository, IUnitOfWork unitOfWork)
        {
            this._lenhSanXuat_NVLRepository = lenhSanXuat_NVLRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(LenhSanXuat_NVL lenhSanXuat_NVL)
        {
            _lenhSanXuat_NVLRepository.Add(lenhSanXuat_NVL);
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
            _lenhSanXuat_NVLRepository.Delete(id);
        }

        public IEnumerable<LenhSanXuat_NVL> GetAll()
        {
            return _lenhSanXuat_NVLRepository.GetAll();
        }

        public LenhSanXuat_NVL GetByID(int id)
        {
            return _lenhSanXuat_NVLRepository.GetSingleById(id);
        }

       

        public void Update(LenhSanXuat_NVL lenhSanXuat_NVL)
        {
            _lenhSanXuat_NVLRepository.Update(lenhSanXuat_NVL);
        }

        public IQueryable<getlenhsanxuatNVL> getlenhsanxuatNVL(string MaLenhSanXuat)
        {
            return _lenhSanXuat_NVLRepository.getlenhsanxuatNVL(MaLenhSanXuat);
        }
    }
}
