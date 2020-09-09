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
    public interface IHeThongTaiKhoanService
    {
        void Add(HeThongTaiKhoan heThongTaiKhoan);
        void Update(HeThongTaiKhoan heThongTaiKhoan);
        void delete(int id);
        IEnumerable<HeThongTaiKhoan> GetAll();
        HeThongTaiKhoan getID(string id);


        HeThongTaiKhoan GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class HeThongTaiKhoanService : IHeThongTaiKhoanService
    {
        IHeThongTaiKhoanRepository _heThongTaiKhoanRepository;
        IUnitOfWork _unitOfWork;
        public HeThongTaiKhoanService(IHeThongTaiKhoanRepository HeThongTaiKhoanRepository, IUnitOfWork unitOfWork)
        {
            this._heThongTaiKhoanRepository = HeThongTaiKhoanRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(HeThongTaiKhoan heThongTaiKhoan)
        {
            _heThongTaiKhoanRepository.Add(heThongTaiKhoan);
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
            _heThongTaiKhoanRepository.Delete(id);
        }

        public IEnumerable<HeThongTaiKhoan> GetAll()
        {
            return _heThongTaiKhoanRepository.GetAll();
        }

        public HeThongTaiKhoan GetByID(int id)
        {
            return _heThongTaiKhoanRepository.GetSingleById(id);
        }

       

        public void Update(HeThongTaiKhoan heThongTaiKhoan)
        {
            _heThongTaiKhoanRepository.Update(heThongTaiKhoan);
        }

        public HeThongTaiKhoan getID(string id)
        {
            return _heThongTaiKhoanRepository.GetSingleById(id);
        }
    }
}
