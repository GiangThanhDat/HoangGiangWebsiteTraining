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
    public interface IDieuKhoanTTService
    {
        void Add(DieuKhoanTT dieuKhoanTT);
        void Update(DieuKhoanTT dieuKhoanTT);
        void delete(int id);
        IEnumerable<DieuKhoanTT> GetAll();
        DieuKhoanTT GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class DieuKhoanTTService : IDieuKhoanTTService
    {
        IDieuKhoanTTRepository _dieuKhoanTTRepository;
        IUnitOfWork _unitOfWork;
        public DieuKhoanTTService(IDieuKhoanTTRepository dieuKhoanTTRepository, IUnitOfWork unitOfWork)
        {
            this._dieuKhoanTTRepository = dieuKhoanTTRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(DieuKhoanTT dieuKhoanTT)
        {
            _dieuKhoanTTRepository.Add(dieuKhoanTT);
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
            _dieuKhoanTTRepository.Delete(id);
        }

        public IEnumerable<DieuKhoanTT> GetAll()
        {
            return _dieuKhoanTTRepository.GetAll();
        }

        public DieuKhoanTT GetByID(int id)
        {
            return _dieuKhoanTTRepository.GetSingleById(id);
        }

       

        public void Update(DieuKhoanTT dieuKhoanTT)
        {
            _dieuKhoanTTRepository.Update(dieuKhoanTT);
        }

       
    }
}
