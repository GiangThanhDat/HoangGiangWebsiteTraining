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
    public interface IHoaDon_BanHangService
    {
        void Add(HoaDon_BanHang hoaDon_BanHang);
        void Update(HoaDon_BanHang hoaDon_BanHang);
        void delete(int id);
        IEnumerable<HoaDon_BanHang> GetAll();
        HoaDon_BanHang GetByID(int id);
        IQueryable<getxuathoadonbanhang> getxuathoadonbanhang(DateTime ngaydau, DateTime ngaycuoi);
        void Commit();
        void Save();

    }
    public class HoaDon_BanHangService : IHoaDon_BanHangService
    {
        IHoaDon_BanHangRepository _hoaDon_BanHangRepository;
        IUnitOfWork _unitOfWork;
        public HoaDon_BanHangService(IHoaDon_BanHangRepository hoaDon_BanHangRepository, IUnitOfWork unitOfWork)
        {
            this._hoaDon_BanHangRepository = hoaDon_BanHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(HoaDon_BanHang hoaDon_BanHang)
        {
            _hoaDon_BanHangRepository.Add(hoaDon_BanHang);
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
            _hoaDon_BanHangRepository.Delete(id);
        }

        public IEnumerable<HoaDon_BanHang> GetAll()
        {
            return _hoaDon_BanHangRepository.GetAll();
        }

        public HoaDon_BanHang GetByID(int id)
        {
            return _hoaDon_BanHangRepository.GetSingleById(id);
        }

       

        public void Update(HoaDon_BanHang hoaDon_BanHang)
        {
            _hoaDon_BanHangRepository.Update(hoaDon_BanHang);
        }

        public IQueryable<getxuathoadonbanhang> getxuathoadonbanhang(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _hoaDon_BanHangRepository.getxuathoadonbanhang(ngaydau, ngaycuoi);
        }
    }
}
