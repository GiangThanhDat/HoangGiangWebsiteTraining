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
    public interface ITaiKhoanNganHangService
    {
        void Add(TaiKhoanNganHang taiKhoanNganHang);
        void Update(TaiKhoanNganHang taiKhoanNganHang);
        void delete(int id);
        IEnumerable<TaiKhoanNganHang> GetAll();
        TaiKhoanNganHang GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class TaiKhoanNganHangService : ITaiKhoanNganHangService
    {
        ITaiKhoanNganHangRepository _taiKhoanNganHangRepository;
        IUnitOfWork _unitOfWork;
        public TaiKhoanNganHangService(ITaiKhoanNganHangRepository taiKhoanNganHangRepository, IUnitOfWork unitOfWork)
        {
            this._taiKhoanNganHangRepository = taiKhoanNganHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(TaiKhoanNganHang taiKhoanNganHang)
        {
            _taiKhoanNganHangRepository.Add(taiKhoanNganHang);
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
            _taiKhoanNganHangRepository.Delete(id);
        }

        public IEnumerable<TaiKhoanNganHang> GetAll()
        {
            return _taiKhoanNganHangRepository.GetAll();
        }

        public TaiKhoanNganHang GetByID(int id)
        {
            return _taiKhoanNganHangRepository.GetSingleById(id);
        }

       

        public void Update(TaiKhoanNganHang taiKhoanNganHang)
        {
            _taiKhoanNganHangRepository.Update(taiKhoanNganHang);
        }

       
    }
}
