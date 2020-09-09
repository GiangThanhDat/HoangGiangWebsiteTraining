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
    public interface IKhachHangService
    {
        void Add(KhachHang khachHang);
        void Update(KhachHang khachHang);
        void delete(int id);
        KhachHang DELETE(int ID);
        IEnumerable<KhachHang> GetAll();
        IEnumerable<KhachHang> GetByKeyWord(string keyword);
        KhachHang GetByID(int id);
        KhachHang GetByID(string id);
       
        void Commit();
        void Save();


    }
    public class KhachHangService : IKhachHangService
    {
        IKhachHangRepository _khachHangRepository;
        IUnitOfWork _unitOfWork;
        public KhachHangService(IKhachHangRepository khachHangRepository, IUnitOfWork unitOfWork)
        {
            this._khachHangRepository = khachHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(KhachHang khachHang)
        {
            _khachHangRepository.Add(khachHang);
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
            _khachHangRepository.Delete(id);
        }

        public IEnumerable<KhachHang> GetAll()
        {
            return _khachHangRepository.GetAll();
        }

        public KhachHang GetByID(int id)
        {
            return _khachHangRepository.GetSingleById(id);
        }



        public void Update(KhachHang khachHang)
        {
            _khachHangRepository.Update(khachHang);
        }

       
      
        public KhachHang DELETE(int ID)
        {
            return _khachHangRepository.Delete(ID);
        }

        public IEnumerable<KhachHang> GetByKeyWord(string keyword)
        {
            return _khachHangRepository.GetMulti(x=>x.TenKhachHang.Contains(keyword)||x.DiaChi.Contains(keyword)||x.MaKhachHang.Contains(keyword));
        }

        public KhachHang GetByID(string id)
        {
            return _khachHangRepository.GetSingleById(id);
        }
    }
}
