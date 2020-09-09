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
    public interface IDichVuService
    {
        void Add(DichVu dichVu);
        void Update(DichVu dichVu);
        void delete(int id);
        IEnumerable<DichVu> GetAll();
        DichVu GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class DichVuService : IDichVuService
    {
        IDichVuRepository _dichVuRepository;
        IUnitOfWork _unitOfWork;
        public DichVuService(IDichVuRepository dichVuRepository, IUnitOfWork unitOfWork)
        {
            this._dichVuRepository = dichVuRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(DichVu dichVu)
        {
            _dichVuRepository.Add(dichVu);
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
            _dichVuRepository.Delete(id);
        }

        public IEnumerable<DichVu> GetAll()
        {
            return _dichVuRepository.GetAll();
        }

        public DichVu GetByID(int id)
        {
            return _dichVuRepository.GetSingleById(id);
        }

       

        public void Update(DichVu dichVu)
        {
            _dichVuRepository.Update(dichVu);
        }

       
    }
}
