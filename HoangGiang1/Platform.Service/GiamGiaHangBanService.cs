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
    public interface IGiamGiaHangBanService
    {
        void Add(GiamGiaHangBan giamGiaHangBan);
        void Update(GiamGiaHangBan giamGiaHangBan);
        void delete(int id);
        IEnumerable<GiamGiaHangBan> GetAll();
        GiamGiaHangBan GetByID(int id);
        IQueryable<getgiamgiahangban> getgiamgiahangban(DateTime ngaydau, DateTime ngaycuoi);
        void Commit();
        void Save();

    }
    public class GiamGiaHangBanService : IGiamGiaHangBanService
    {
        IGiamGiaHangBanRepository _giamGiaHangBanRepository;
        IUnitOfWork _unitOfWork;
        public GiamGiaHangBanService(IGiamGiaHangBanRepository giamGiaHangBanRepository, IUnitOfWork unitOfWork)
        {
            this._giamGiaHangBanRepository = giamGiaHangBanRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(GiamGiaHangBan giamGiaHangBan)
        {
            _giamGiaHangBanRepository.Add(giamGiaHangBan);
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
            _giamGiaHangBanRepository.Delete(id);
        }

        public IEnumerable<GiamGiaHangBan> GetAll()
        {
            return _giamGiaHangBanRepository.GetAll();
        }

        public GiamGiaHangBan GetByID(int id)
        {
            return _giamGiaHangBanRepository.GetSingleById(id);
        }

       

        public void Update(GiamGiaHangBan giamGiaHangBan)
        {
            _giamGiaHangBanRepository.Update(giamGiaHangBan);
        }

        public IQueryable<getgiamgiahangban> getgiamgiahangban(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _giamGiaHangBanRepository.getgiamgiahangban(ngaydau, ngaycuoi);
        }
    }
}
