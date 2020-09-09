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
    public interface ITinhTrangService
    {
        void Add(TinhTrang tinhTrang);
        void Update(TinhTrang tinhTrang);
        void delete(int id);
        IEnumerable<TinhTrang> GetAll();
        TinhTrang GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class TinhTrangService : ITinhTrangService
    {
        ITinhTrangRepository _tinhTrangRepository;
        IUnitOfWork _unitOfWork;
        public TinhTrangService(ITinhTrangRepository tinhTrangRepository, IUnitOfWork unitOfWork)
        {
            this._tinhTrangRepository = tinhTrangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(TinhTrang tinhTrang)
        {
            _tinhTrangRepository.Add(tinhTrang);
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
            _tinhTrangRepository.Delete(id);
        }

        public IEnumerable<TinhTrang> GetAll()
        {
            return _tinhTrangRepository.GetAll();
        }

        public TinhTrang GetByID(int id)
        {
            return _tinhTrangRepository.GetSingleById(id);
        }

       

        public void Update(TinhTrang tinhTrang)
        {
            _tinhTrangRepository.Update(tinhTrang);
        }

       
    }
}
