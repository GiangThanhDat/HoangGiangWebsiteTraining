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
    public interface ILoaiTaiSanCoDinhService
    {
        void Add(LoaiTaiSanCoDinh loaiTaiSanCoDinh);
        void Update(LoaiTaiSanCoDinh loaiTaiSanCoDinh);
        void delete(int id);
        IEnumerable<LoaiTaiSanCoDinh> GetAll();
        LoaiTaiSanCoDinh GetByID(int id);
        LoaiTaiSanCoDinh GetByID(string id);
      
        void Commit();
        void Save();

    }
    public class LoaiTaiSanCoDinhService : ILoaiTaiSanCoDinhService
    {
        ILoaiTaiSanCoDinhRepository _loaiTaiSanCoDinhRepository;
        IUnitOfWork _unitOfWork;
        public LoaiTaiSanCoDinhService(ILoaiTaiSanCoDinhRepository loaiTaiSanCoDinhRepository, IUnitOfWork unitOfWork)
        {
            this._loaiTaiSanCoDinhRepository = loaiTaiSanCoDinhRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(LoaiTaiSanCoDinh loaiTaiSanCoDinh)
        {
            _loaiTaiSanCoDinhRepository.Add(loaiTaiSanCoDinh);
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
            _loaiTaiSanCoDinhRepository.Delete(id);
        }

        public IEnumerable<LoaiTaiSanCoDinh> GetAll()
        {
            return _loaiTaiSanCoDinhRepository.GetAll();
        }

        public LoaiTaiSanCoDinh GetByID(int id)
        {
            return _loaiTaiSanCoDinhRepository.GetSingleById(id);
        }

       

        public void Update(LoaiTaiSanCoDinh loaiTaiSanCoDinh)
        {
            _loaiTaiSanCoDinhRepository.Update(loaiTaiSanCoDinh);
        }

        public LoaiTaiSanCoDinh GetByID(string id)
        {
            return _loaiTaiSanCoDinhRepository.GetSingleById(id);
        }
    }
}
