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
    public interface IChiTietGiamGiaHangBanService
    {
        void Add(ChiTietGiamGiaHangBan chiTietGiamGiaHangBan);
        void Update(ChiTietGiamGiaHangBan chiTietGiamGiaHangBan);
        void delete(int id);
        IEnumerable<ChiTietGiamGiaHangBan> GetAll();
        ChiTietGiamGiaHangBan GetByID(int id);
        IQueryable<getchitietgiamgiahangban> getchitietgiamgiahangban(string MaGiamGiaHangBan);
        void Commit();
        void Save();

    }
    public class ChiTietGiamGiaHangBanService : IChiTietGiamGiaHangBanService
    {
        IChiTietGiamGiaHangBanRepository _chiTietGiamGiaHangBanRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietGiamGiaHangBanService(IChiTietGiamGiaHangBanRepository chiTietGiamGiaHangBanRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietGiamGiaHangBanRepository = chiTietGiamGiaHangBanRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietGiamGiaHangBan chiTietGiamGiaHangBan)
        {
            _chiTietGiamGiaHangBanRepository.Add(chiTietGiamGiaHangBan);
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
            _chiTietGiamGiaHangBanRepository.Delete(id);
        }

        public IEnumerable<ChiTietGiamGiaHangBan> GetAll()
        {
            return _chiTietGiamGiaHangBanRepository.GetAll();
        }

        public ChiTietGiamGiaHangBan GetByID(int id)
        {
            return _chiTietGiamGiaHangBanRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietGiamGiaHangBan chiTietGiamGiaHangBan)
        {
            _chiTietGiamGiaHangBanRepository.Update(chiTietGiamGiaHangBan);
        }

        public IQueryable<getchitietgiamgiahangban> getchitietgiamgiahangban(string MaGiamGiaHangBan)
        {
            return _chiTietGiamGiaHangBanRepository.getchitietgiamgiahangban(MaGiamGiaHangBan);
        }
    }
}
