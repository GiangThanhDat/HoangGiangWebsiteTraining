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
    public interface IChiTietHoaDon_BanHangService
    {
        void Add(ChiTietHoaDon_BanHang chiTietHoaDon_BanHang);
        void Update(ChiTietHoaDon_BanHang chiTietHoaDon_BanHang);
        void delete(int id);
        IEnumerable<ChiTietHoaDon_BanHang> GetAll();
        ChiTietHoaDon_BanHang GetByID(int id);
        IQueryable<getchitiethoadonbanhang> getchitiethoadonbanhang(string MaHoaDon);
        void Commit();
        void Save();

    }
    public class ChiTietHoaDon_BanHangService : IChiTietHoaDon_BanHangService
    {
        IChiTietHoaDon_BanHangRepository _chiTietHoaDon_BanHangRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietHoaDon_BanHangService(IChiTietHoaDon_BanHangRepository chiTietHoaDon_BanHangRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietHoaDon_BanHangRepository = chiTietHoaDon_BanHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietHoaDon_BanHang chiTietHoaDon_BanHang)
        {
            _chiTietHoaDon_BanHangRepository.Add(chiTietHoaDon_BanHang);
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
            _chiTietHoaDon_BanHangRepository.Delete(id);
        }

        public IEnumerable<ChiTietHoaDon_BanHang> GetAll()
        {
            return _chiTietHoaDon_BanHangRepository.GetAll();
        }

        public ChiTietHoaDon_BanHang GetByID(int id)
        {
            return _chiTietHoaDon_BanHangRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietHoaDon_BanHang chiTietHoaDon_BanHang)
        {
            _chiTietHoaDon_BanHangRepository.Update(chiTietHoaDon_BanHang);
        }

        public IQueryable<getchitiethoadonbanhang> getchitiethoadonbanhang(string MaHoaDon)
        {
            return _chiTietHoaDon_BanHangRepository.getchitiethoadonbanhang(MaHoaDon);
        }
    }
}
