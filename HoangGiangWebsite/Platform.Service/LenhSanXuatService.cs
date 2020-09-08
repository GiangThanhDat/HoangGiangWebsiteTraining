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
    public interface ILenhSanXuatService
    {
        void Add(LenhSanXuat lenhSanXuat);
        void Update(LenhSanXuat lenhSanXuat);
        void delete(int id);
        IEnumerable<LenhSanXuat> GetAll();
        LenhSanXuat GetByID(int id);
        IQueryable<getLenhSanXuat> getLenhSanXuat(DateTime ngaydau, DateTime ngaycuoi);

        void Commit();
        void Save();

    }
    public class LenhSanXuatService : ILenhSanXuatService
    {
        ILenhSanXuatRepository _lenhSanXuatRepository;
        IUnitOfWork _unitOfWork;
        public LenhSanXuatService(ILenhSanXuatRepository lenhSanXuatRepository, IUnitOfWork unitOfWork)
        {
            this._lenhSanXuatRepository = lenhSanXuatRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(LenhSanXuat lenhSanXuat)
        {
            _lenhSanXuatRepository.Add(lenhSanXuat);
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
            _lenhSanXuatRepository.Delete(id);
        }

        public IEnumerable<LenhSanXuat> GetAll()
        {
            return _lenhSanXuatRepository.GetAll();
        }

        public LenhSanXuat GetByID(int id)
        {
            return _lenhSanXuatRepository.GetSingleById(id);
        }



        public void Update(LenhSanXuat lenhSanXuat)
        {
            _lenhSanXuatRepository.Update(lenhSanXuat);
        }

        public IQueryable<getLenhSanXuat> getLenhSanXuat(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _lenhSanXuatRepository.getLenhSanXuat(ngaydau, ngaycuoi);
        }
    }
}
