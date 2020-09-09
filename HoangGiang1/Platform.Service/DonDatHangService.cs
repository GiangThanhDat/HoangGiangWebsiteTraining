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
    public interface IDonDatHangService
    {
        void Add(DonDatHang donDatHang);
        void Update(DonDatHang donDatHang);
        void delete(int id);
        IEnumerable<DonDatHang> GetAll();
        DonDatHang GetByID(int id);
        IQueryable<getdondathang> gettdondathang(DateTime ngaydau, DateTime ngaycuoi);

        void Commit();
        void Save();

    }
    public class DonDatHangService : IDonDatHangService
    {
        IDonDatHangRepository _donDatHangRepository;
        IUnitOfWork _unitOfWork;
        public DonDatHangService(IDonDatHangRepository donDatHangRepository, IUnitOfWork unitOfWork)
        {
            this._donDatHangRepository = donDatHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(DonDatHang donDatHang)
        {
            _donDatHangRepository.Add(donDatHang);
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
            _donDatHangRepository.Delete(id);
        }

        public IEnumerable<DonDatHang> GetAll()
        {
            return _donDatHangRepository.GetAll();
        }

        public DonDatHang GetByID(int id)
        {
            return _donDatHangRepository.GetSingleById(id);
        }

       

        public void Update(DonDatHang donDatHang)
        {
            _donDatHangRepository.Update(donDatHang);
        }

        public IQueryable<getdondathang> gettdondathang(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _donDatHangRepository.gettdondathang(ngaydau, ngaycuoi);
        }
    }
}
