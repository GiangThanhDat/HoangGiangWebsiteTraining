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
    public interface IChiTietTraLaiHangBanService
    {
        void Add(ChiTietTraLaiHangBan chiTietTraLaiHangBan);
        void Update(ChiTietTraLaiHangBan chiTietTraLaiHangBan);
        void delete(int id);
        IEnumerable<ChiTietTraLaiHangBan> GetAll();
        IEnumerable<ChiTietTraLaiHangBan> getbyid(string id);
        ChiTietTraLaiHangBan GetByID(int id);
        IQueryable<getchitiettralaihangban> getchitiettralaihangban(string MaTraLaiHangBan);
        void Commit();
        void Save();

    }
    public class ChiTietTraLaiHangBanService : IChiTietTraLaiHangBanService
    {
        IChiTietTraLaiHangBanRepository _chiTietTraLaiHangBanRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietTraLaiHangBanService(IChiTietTraLaiHangBanRepository chiTietTraLaiHangBanRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietTraLaiHangBanRepository = chiTietTraLaiHangBanRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietTraLaiHangBan chiTietTraLaiHangBan)
        {
            _chiTietTraLaiHangBanRepository.Add(chiTietTraLaiHangBan);
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
            _chiTietTraLaiHangBanRepository.Delete(id);
        }

        public IEnumerable<ChiTietTraLaiHangBan> GetAll()
        {
            return _chiTietTraLaiHangBanRepository.GetAll();
        }

        public ChiTietTraLaiHangBan GetByID(int id)
        {
            return _chiTietTraLaiHangBanRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietTraLaiHangBan chiTietTraLaiHangBan)
        {
            _chiTietTraLaiHangBanRepository.Update(chiTietTraLaiHangBan);
        }

        public IQueryable<getchitiettralaihangban> getchitiettralaihangban(string MaTraLaiHangBan)
        {
            return _chiTietTraLaiHangBanRepository.getchitiettralaihangban(MaTraLaiHangBan);
        }

        public IEnumerable<ChiTietTraLaiHangBan> getbyid(string id)
        {
            return _chiTietTraLaiHangBanRepository.GetMulti(x=>x.MaTraLaiHangBan==id);
        }
    }
}
