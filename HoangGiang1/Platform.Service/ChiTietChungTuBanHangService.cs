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
    public interface IChiTietChungTuBanHangService
    {
        void Add(ChiTietChungTuBanHang chiTietChungTuBanHang);
        void Update(ChiTietChungTuBanHang chiTietChungTuBanHang);
        void delete(int id);
        IEnumerable<ChiTietChungTuBanHang> GetAll();
        IEnumerable<ChiTietChungTuBanHang> getbyid(string id); 
        IQueryable<getchitietchungtubanhang> getchitietchungtubanhang(string MaChungTuBanHang);
        IEnumerable<thongketop10> thongkechitietchungtubanhang(DateTime ngaydau, DateTime ngaycuoi, bool dathaydoi);

        ChiTietChungTuBanHang GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class ChiTietChungTuBanHangService : IChiTietChungTuBanHangService
    {
        IChiTietChungTuBanHangRepository _chiTietChungTuBanHangRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietChungTuBanHangService(IChiTietChungTuBanHangRepository chiTietChungTuBanHangRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietChungTuBanHangRepository = chiTietChungTuBanHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietChungTuBanHang chiTietChungTuBanHang)
        {
            _chiTietChungTuBanHangRepository.Add(chiTietChungTuBanHang);
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
            _chiTietChungTuBanHangRepository.Delete(id);
        }

        public IEnumerable<ChiTietChungTuBanHang> GetAll()
        {
            return _chiTietChungTuBanHangRepository.GetAll();
        }

        public ChiTietChungTuBanHang GetByID(int id)
        {
            return _chiTietChungTuBanHangRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietChungTuBanHang chiTietChungTuBanHang)
        {
            _chiTietChungTuBanHangRepository.Update(chiTietChungTuBanHang);
        }

        public IEnumerable<ChiTietChungTuBanHang> getbyid(string id)
        {
           return _chiTietChungTuBanHangRepository.GetMulti(x=>x.MaChungTuBanHang==id);
        }

        public IQueryable<getchitietchungtubanhang> getchitietchungtubanhang(string MaChungTuBanHang)
        {
            return _chiTietChungTuBanHangRepository.getchitietchungtubanhang(MaChungTuBanHang);
        }

        public IEnumerable<thongketop10> thongkechitietchungtubanhang(DateTime ngaydau, DateTime ngaycuoi, bool dathaydoi)
        {
            return _chiTietChungTuBanHangRepository.thongkechitietchungtubanhang(ngaydau, ngaycuoi, dathaydoi);
        }
    }
}
