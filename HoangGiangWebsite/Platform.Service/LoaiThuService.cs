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
    public interface ILoaiThuService
    {
        void Add(LoaiThu loaiThu);
        void Update(LoaiThu loaiThu);
        void delete(int id);
        IEnumerable<LoaiThu> GetAll();
        LoaiThu GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class LoaiThuService : ILoaiThuService
    {
        ILoaiThuRepository _loaiThuRepository;
        IUnitOfWork _unitOfWork;
        public LoaiThuService(ILoaiThuRepository loaiThuRepository, IUnitOfWork unitOfWork)
        {
            this._loaiThuRepository = loaiThuRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(LoaiThu loaiThu)
        {
            _loaiThuRepository.Add(loaiThu);
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
            _loaiThuRepository.Delete(id);
        }

        public IEnumerable<LoaiThu> GetAll()
        {
            return _loaiThuRepository.GetAll();
        }

        public LoaiThu GetByID(int id)
        {
            return _loaiThuRepository.GetSingleById(id);
        }

       

        public void Update(LoaiThu loaiThu)
        {
            _loaiThuRepository.Update(loaiThu);
        }

       
    }
}
