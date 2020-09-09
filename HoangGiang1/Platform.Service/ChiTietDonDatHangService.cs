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
    public interface IChiTietDonDatHangService
    {
        void Add(ChiTietDonDatHang chiTietDonDatHang);
        void Update(ChiTietDonDatHang chiTietDonDatHang);
        void delete(int id);
        IEnumerable<ChiTietDonDatHang> GetAll();
        ChiTietDonDatHang GetByID(int id);
        IQueryable<getchitietdondathang> getchitietdondathang(string MaDonDatHang);
        void Commit();
        void Save();

    }
    public class ChiTietDonDatHangService : IChiTietDonDatHangService
    {
        IChiTietDonDatHangRepository _chiTietDonDatHangRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietDonDatHangService(IChiTietDonDatHangRepository chiTietDonDatHangRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietDonDatHangRepository = chiTietDonDatHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietDonDatHang chiTietDonDatHang)
        {
            _chiTietDonDatHangRepository.Add(chiTietDonDatHang);
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
            _chiTietDonDatHangRepository.Delete(id);
        }

        public IEnumerable<ChiTietDonDatHang> GetAll()
        {
            return _chiTietDonDatHangRepository.GetAll();
        }

        public ChiTietDonDatHang GetByID(int id)
        {
            return _chiTietDonDatHangRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietDonDatHang chiTietDonDatHang)
        {
            _chiTietDonDatHangRepository.Update(chiTietDonDatHang);
        }

        public IQueryable<getchitietdondathang> getchitietdondathang(string MaDonDatHang)
        {
            return _chiTietDonDatHangRepository.getchitietdondathang(MaDonDatHang);
        }
    }
}
