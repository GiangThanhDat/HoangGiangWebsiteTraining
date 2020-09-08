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
    public interface ITaiKhoanKetChuyenService
    {
        void Add(TaiKhoanKetChuyen taiKhoanKetChuyen);
        void Update(TaiKhoanKetChuyen taiKhoanKetChuyen);
        void delete(int id);
        IEnumerable<TaiKhoanKetChuyen> GetAll();
        TaiKhoanKetChuyen getID(string id);


        TaiKhoanKetChuyen GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class TaiKhoanKetChuyenService : ITaiKhoanKetChuyenService
    {
        ITaiKhoanKetChuyenRepository _taiKhoanKetChuyenRepository;
        IUnitOfWork _unitOfWork;
        public TaiKhoanKetChuyenService(ITaiKhoanKetChuyenRepository taiKhoanKetChuyenRepository, IUnitOfWork unitOfWork)
        {
            this._taiKhoanKetChuyenRepository = taiKhoanKetChuyenRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(TaiKhoanKetChuyen taiKhoanKetChuyen)
        {
            _taiKhoanKetChuyenRepository.Add(taiKhoanKetChuyen);
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
            _taiKhoanKetChuyenRepository.Delete(id);
        }

        public IEnumerable<TaiKhoanKetChuyen> GetAll()
        {
            return _taiKhoanKetChuyenRepository.GetAll();
        }

        public TaiKhoanKetChuyen GetByID(int id)
        {
            return _taiKhoanKetChuyenRepository.GetSingleById(id);
        }

       

        public void Update(TaiKhoanKetChuyen taiKhoanKetChuyen)
        {
            _taiKhoanKetChuyenRepository.Update(taiKhoanKetChuyen);
        }

        public TaiKhoanKetChuyen getID(string id)
        {
            return _taiKhoanKetChuyenRepository.GetSingleById(id);
        }
    }
}
