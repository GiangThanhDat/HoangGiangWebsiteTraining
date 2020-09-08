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
    public interface INhaCungCap_TaiKhoanService
    {
        void Add(NhaCungCap_TaiKhoan NhaCungCap_TaiKhoan);
        void Update(NhaCungCap_TaiKhoan NhaCungCap_TaiKhoan);
        void delete(int id);
        IEnumerable<NhaCungCap_TaiKhoan> GetAll();
        NhaCungCap_TaiKhoan GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class NhaCungCap_TaiKhoanService : INhaCungCap_TaiKhoanService
    {
        INhaCungCap_TaiKhoanRepository _NhaCungCap_TaiKhoanRepository;
        IUnitOfWork _unitOfWork;
        public NhaCungCap_TaiKhoanService(INhaCungCap_TaiKhoanRepository NhaCungCap_TaiKhoanRepository, IUnitOfWork unitOfWork)
        {
            this._NhaCungCap_TaiKhoanRepository = NhaCungCap_TaiKhoanRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(NhaCungCap_TaiKhoan NhaCungCap_TaiKhoan)
        {
            _NhaCungCap_TaiKhoanRepository.Add(NhaCungCap_TaiKhoan);
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
            _NhaCungCap_TaiKhoanRepository.Delete(id);
        }

        public IEnumerable<NhaCungCap_TaiKhoan> GetAll()
        {
            return _NhaCungCap_TaiKhoanRepository.GetAll();
        }

        public NhaCungCap_TaiKhoan GetByID(int id)
        {
            return _NhaCungCap_TaiKhoanRepository.GetSingleById(id);
        }

       

        public void Update(NhaCungCap_TaiKhoan NhaCungCap_TaiKhoan)
        {
            _NhaCungCap_TaiKhoanRepository.Update(NhaCungCap_TaiKhoan);
        }

       
    }
}
