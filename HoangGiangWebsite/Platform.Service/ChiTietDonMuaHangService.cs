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
    public interface IChiTietDonMuaHangService
    {
        void Add(ChiTietDonMuaHang chiTietDonMuaHang);
        void Update(ChiTietDonMuaHang chiTietDonMuaHang);
        void delete(int id);
        IEnumerable<ChiTietDonMuaHang> GetAll();
        ChiTietDonMuaHang GetByID(int id);
        IQueryable<getchitietmuahang> getchitiet(string maMH);
        void Commit();
        void Save();

    }
    public class ChiTietDonMuaHangService : IChiTietDonMuaHangService
    {
        IChiTietDonMuaHangRepository _chiTietDonMuaHangRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietDonMuaHangService(IChiTietDonMuaHangRepository chiTietDonMuaHangRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietDonMuaHangRepository = chiTietDonMuaHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietDonMuaHang chiTietDonMuaHang)
        {
            _chiTietDonMuaHangRepository.Add(chiTietDonMuaHang);
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
            _chiTietDonMuaHangRepository.Delete(id);
        }

        public IEnumerable<ChiTietDonMuaHang> GetAll()
        {
            return _chiTietDonMuaHangRepository.GetAll();
        }

        public ChiTietDonMuaHang GetByID(int id)
        {
            return _chiTietDonMuaHangRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietDonMuaHang chiTietDonMuaHang)
        {
            _chiTietDonMuaHangRepository.Update(chiTietDonMuaHang);
        }

        public IQueryable<getchitietmuahang> getchitiet(string maMH)
        {
            return _chiTietDonMuaHangRepository.getchitiet(maMH);
        }
    }
}
