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
    public interface ITraLaiHangMuaService
    {
        void Add(TraLaiHangMua traLaiHangMua);
        void Update(TraLaiHangMua traLaiHangMua);
        void delete(int id);
        IEnumerable<TraLaiHangMua> GetAll();
        TraLaiHangMua GetByID(int id);
        IQueryable<gettralaihangmua> gettralaihangmua(DateTime ngaydau, DateTime ngaycuoi);
        void Commit();
        void Save();

    }
    public class TraLaiHangMuaService : ITraLaiHangMuaService
    {
        ITraLaiHangMuaRepository _traLaiHangMuaRepository;
        IUnitOfWork _unitOfWork;
        public TraLaiHangMuaService(ITraLaiHangMuaRepository traLaiHangMuaRepository, IUnitOfWork unitOfWork)
        {
            this._traLaiHangMuaRepository = traLaiHangMuaRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(TraLaiHangMua traLaiHangMua)
        {
            _traLaiHangMuaRepository.Add(traLaiHangMua);
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
            _traLaiHangMuaRepository.Delete(id);
        }

        public IEnumerable<TraLaiHangMua> GetAll()
        {
            return _traLaiHangMuaRepository.GetAll();
        }

        public TraLaiHangMua GetByID(int id)
        {
            return _traLaiHangMuaRepository.GetSingleById(id);
        }

       

        public void Update(TraLaiHangMua traLaiHangMua)
        {
            _traLaiHangMuaRepository.Update(traLaiHangMua);
        }

        public IQueryable<gettralaihangmua> gettralaihangmua(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _traLaiHangMuaRepository.gettralaihangmua(ngaydau, ngaycuoi);
        }
    }
}
