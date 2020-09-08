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
    public interface ITraLaiHangBanService
    {
        void Add(TraLaiHangBan traLaiHangBan);
        void Update(TraLaiHangBan traLaiHangBan);
        void delete(int id);
        IEnumerable<TraLaiHangBan> GetAll();
        TraLaiHangBan GetByID(int id);
        IQueryable<gettralaihangban> gettralaihangban(DateTime ngaydau, DateTime ngaycuoi);
        void Commit();
        void Save();

    }
    public class TraLaiHangBanService : ITraLaiHangBanService
    {
        ITraLaiHangBanRepository _traLaiHangBanRepository;
        IUnitOfWork _unitOfWork;
        public TraLaiHangBanService(ITraLaiHangBanRepository traLaiHangBanRepository, IUnitOfWork unitOfWork)
        {
            this._traLaiHangBanRepository = traLaiHangBanRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(TraLaiHangBan traLaiHangBan)
        {
            _traLaiHangBanRepository.Add(traLaiHangBan);
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
            _traLaiHangBanRepository.Delete(id);
        }

        public IEnumerable<TraLaiHangBan> GetAll()
        {
            return _traLaiHangBanRepository.GetAll();
        }

        public TraLaiHangBan GetByID(int id)
        {
            return _traLaiHangBanRepository.GetSingleById(id);
        }

       

        public void Update(TraLaiHangBan traLaiHangBan)
        {
            _traLaiHangBanRepository.Update(traLaiHangBan);
        }

        public IQueryable<gettralaihangban> gettralaihangban(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _traLaiHangBanRepository.gettralaihangban(ngaydau, ngaycuoi);
        }
    }
}
