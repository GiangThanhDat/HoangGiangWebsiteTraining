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
    public interface ILichSuLamViecService
    {
        void Add(LichSuLamViec lichSuLamViec);
        void Update(LichSuLamViec lichSuLamViec);
        void delete(int id);
        LichSuLamViec DELETE(int ID);
        IEnumerable<LichSuLamViec> GetAll();
        LichSuLamViec GetByID(int id);
        IEnumerable<LichSuLamViec> GetLichSuLamViec(string msnv);
        void Commit();
        void Save();
        LichSuLamViec getID(int id);


    }
    public class LichSuLamViecService : ILichSuLamViecService
    {
        ILichSuLamViecRepository _lichSuLamViecRepository;
        IUnitOfWork _unitOfWork;
        public LichSuLamViecService(ILichSuLamViecRepository lichSuLamViecRepository, IUnitOfWork unitOfWork)
        {
            this._lichSuLamViecRepository = lichSuLamViecRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(LichSuLamViec lichSuLamViec)
        {
            _lichSuLamViecRepository.Add(lichSuLamViec);
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
            _lichSuLamViecRepository.Delete(id);
        }

        public IEnumerable<LichSuLamViec> GetAll()
        {
            return _lichSuLamViecRepository.GetAll();
        }

        public LichSuLamViec GetByID(int id)
        {
            return _lichSuLamViecRepository.GetSingleById(id);
        }

      

        public void Update(LichSuLamViec lichSuLamViec)
        {
            _lichSuLamViecRepository.Update(lichSuLamViec);
        }

        public IEnumerable<LichSuLamViec> GetLichSuLamViec(string msnv)
        {
            return _lichSuLamViecRepository.GetLichSuLamViec(msnv);
        }

        public LichSuLamViec getID(int id)
        {
            return _lichSuLamViecRepository.getID(id);
        }

        public LichSuLamViec DELETE(int ID)
        {
            return _lichSuLamViecRepository.Delete(ID);
        }
    }
}
