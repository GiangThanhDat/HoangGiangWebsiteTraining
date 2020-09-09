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
    public interface IKhachHang_TaiKhoanService
    {
        void Add(KhachHang_TaiKhoan khachHang_TaiKhoan);
        void Update(KhachHang_TaiKhoan khachHang_TaiKhoan);
        void delete(int id);
        IEnumerable<KhachHang_TaiKhoan> GetAll();
        KhachHang_TaiKhoan GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class KhachHang_TaiKhoanService : IKhachHang_TaiKhoanService
    {
        IKhachHang_TaiKhoanRepository _khachHang_TaiKhoanRepository;
        IUnitOfWork _unitOfWork;
        public KhachHang_TaiKhoanService(IKhachHang_TaiKhoanRepository khachHang_TaiKhoanRepository, IUnitOfWork unitOfWork)
        {
            this._khachHang_TaiKhoanRepository = khachHang_TaiKhoanRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(KhachHang_TaiKhoan khachHang_TaiKhoan)
        {
            _khachHang_TaiKhoanRepository.Add(khachHang_TaiKhoan);
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
            _khachHang_TaiKhoanRepository.Delete(id);
        }

        public IEnumerable<KhachHang_TaiKhoan> GetAll()
        {
            return _khachHang_TaiKhoanRepository.GetAll();
        }

        public KhachHang_TaiKhoan GetByID(int id)
        {
            return _khachHang_TaiKhoanRepository.GetSingleById(id);
        }

       

        public void Update(KhachHang_TaiKhoan khachHang_TaiKhoan)
        {
            _khachHang_TaiKhoanRepository.Update(khachHang_TaiKhoan);
        }

       
    }
}
