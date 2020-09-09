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
    public interface IChucVuService
    {
        void Add(ChucVu chucVu);
        void Update(ChucVu chucVu);
        void delete(int id);
        IEnumerable<ChucVu> GetAll();
        ChucVu GetByID(int id);
        IEnumerable<ChucVu> getChucVu(string msnv);
        getChucVu getChucVu1(string msnv);

        void Commit();
        void Save();


    }
    public class ChucVuService : IChucVuService
    {
        IChucVuRepository _chucVuRepository;
        IUnitOfWork _unitOfWork;
        public ChucVuService(IChucVuRepository chucVuRepository, IUnitOfWork unitOfWork)
        {
            this._chucVuRepository = chucVuRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChucVu chucVu)
        {
            _chucVuRepository.Add(chucVu);
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
            _chucVuRepository.Delete(id);
        }

        public IEnumerable<ChucVu> GetAll()
        {
            return _chucVuRepository.GetAll();
        }

        public ChucVu GetByID(int id)
        {
            return _chucVuRepository.GetSingleById(id);
        }

       

        public void Update(ChucVu chucVu)
        {
            _chucVuRepository.Update(chucVu);
        }

        public IEnumerable<ChucVu> getChucVu(string msnv)
        {
           return _chucVuRepository.getChucVu(msnv);
        }

        public getChucVu getChucVu1(string msnv)
        {
            return _chucVuRepository.getChucVu1(msnv);
        }
    }
}
