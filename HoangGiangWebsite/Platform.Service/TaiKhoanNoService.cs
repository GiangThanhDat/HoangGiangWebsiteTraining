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
    public interface ITaiKhoanNoService
    {
        void Add(TaiKhoanNo taiKhoanNo);
        void Update(TaiKhoanNo taiKhoanNo);
        void delete(int id);
        IEnumerable<TaiKhoanNo> GetAll();
        TaiKhoanNo GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class TaiKhoanNoService : ITaiKhoanNoService
    {
        ITaiKhoanNoRepository _taiKhoanNoRepository;
        IUnitOfWork _unitOfWork;
        public TaiKhoanNoService(ITaiKhoanNoRepository taiKhoanNoRepository, IUnitOfWork unitOfWork)
        {
            this._taiKhoanNoRepository = taiKhoanNoRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(TaiKhoanNo taiKhoanNo)
        {
            _taiKhoanNoRepository.Add(taiKhoanNo);
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
            _taiKhoanNoRepository.Delete(id);
        }

        public IEnumerable<TaiKhoanNo> GetAll()
        {
            return _taiKhoanNoRepository.GetAll();
        }

        public TaiKhoanNo GetByID(int id)
        {
            return _taiKhoanNoRepository.GetSingleById(id);
        }

       

        public void Update(TaiKhoanNo taiKhoanNo)
        {
            _taiKhoanNoRepository.Update(taiKhoanNo);
        }

       
    }
}
