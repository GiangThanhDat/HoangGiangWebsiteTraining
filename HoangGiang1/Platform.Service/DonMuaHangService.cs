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
    public interface IDonMuaHangService
    {
        void Add(DonMuaHang donMuaHang);
        void Update(DonMuaHang donMuaHang);
        void delete(int id);
        IEnumerable<DonMuaHang> GetAll();
        DonMuaHang GetByID(int id);
        IQueryable<getdonmuahang> getDonMuaHang(DateTime ngaydau, DateTime ngaycuoi);
        void Commit();
        void Save();

    }
    public class DonMuaHangService : IDonMuaHangService
    {
        IDonMuaHangRepository _donMuaHangRepository;
        IUnitOfWork _unitOfWork;
        public DonMuaHangService(IDonMuaHangRepository donMuaHangRepository, IUnitOfWork unitOfWork)
        {
            this._donMuaHangRepository = donMuaHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(DonMuaHang donMuaHang)
        {
            _donMuaHangRepository.Add(donMuaHang);
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
            _donMuaHangRepository.Delete(id);
        }

        public IEnumerable<DonMuaHang> GetAll()
        {
            return _donMuaHangRepository.GetAll();
        }

        public DonMuaHang GetByID(int id)
        {
            return _donMuaHangRepository.GetSingleById(id);
        }

       

        public void Update(DonMuaHang donMuaHang)
        {
            _donMuaHangRepository.Update(donMuaHang);
        }

        public IQueryable<getdonmuahang> getDonMuaHang(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _donMuaHangRepository.getDonMuaHang(ngaydau, ngaycuoi);
        }
    }
}
