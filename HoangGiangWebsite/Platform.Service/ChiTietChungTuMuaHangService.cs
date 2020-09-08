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
    public interface IChiTietChungTuMuaHangService
    {
        void Add(ChiTietChungTuMuaHang chiTietChiTietChungTuMuaHang);
        void Update(ChiTietChungTuMuaHang chiTietChiTietChungTuMuaHang);
        void delete(int id);
        IEnumerable<ChiTietChungTuMuaHang> GetAll();
        ChiTietChungTuMuaHang GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class ChiTietChungTuMuaHangService : IChiTietChungTuMuaHangService
    {
        IChiTietChungTuMuaHangRepository _chiTietChiTietChungTuMuaHangRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietChungTuMuaHangService(IChiTietChungTuMuaHangRepository chiTietChiTietChungTuMuaHangRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietChiTietChungTuMuaHangRepository = chiTietChiTietChungTuMuaHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietChungTuMuaHang chiTietChiTietChungTuMuaHang)
        {
            _chiTietChiTietChungTuMuaHangRepository.Add(chiTietChiTietChungTuMuaHang);
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
            _chiTietChiTietChungTuMuaHangRepository.Delete(id);
        }

        public IEnumerable<ChiTietChungTuMuaHang> GetAll()
        {
            return _chiTietChiTietChungTuMuaHangRepository.GetAll();
        }

        public ChiTietChungTuMuaHang GetByID(int id)
        {
            return _chiTietChiTietChungTuMuaHangRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietChungTuMuaHang chiTietChiTietChungTuMuaHang)
        {
            _chiTietChiTietChungTuMuaHangRepository.Update(chiTietChiTietChungTuMuaHang);
        }

       
    }
}
