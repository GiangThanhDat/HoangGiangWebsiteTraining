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
    public interface ITaiKhoanCoService
    {
        void Add(TaiKhoanCo taiKhoanCo);
        void Update(TaiKhoanCo taiKhoanCo);
        void delete(int id);
        IEnumerable<TaiKhoanCo> GetAll();
        TaiKhoanCo GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class TaiKhoanCoService : ITaiKhoanCoService
    {
        ITaiKhoanCoRepository _taiKhoanCoRepository;
        IUnitOfWork _unitOfWork;
        public TaiKhoanCoService(ITaiKhoanCoRepository taiKhoanCoRepository, IUnitOfWork unitOfWork)
        {
            this._taiKhoanCoRepository = taiKhoanCoRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(TaiKhoanCo taiKhoanCo)
        {
            _taiKhoanCoRepository.Add(taiKhoanCo);
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
            _taiKhoanCoRepository.Delete(id);
        }

        public IEnumerable<TaiKhoanCo> GetAll()
        {
            return _taiKhoanCoRepository.GetAll();
        }

        public TaiKhoanCo GetByID(int id)
        {
            return _taiKhoanCoRepository.GetSingleById(id);
        }

       

        public void Update(TaiKhoanCo taiKhoanCo)
        {
            _taiKhoanCoRepository.Update(taiKhoanCo);
        }

       
    }
}
