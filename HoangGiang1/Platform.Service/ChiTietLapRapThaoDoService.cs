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
    public interface IChiTietLapRapThaoDoService
    {
        void Add(ChiTietLapRapThaoDo chiTietLapRapThaoDo);
        void Update(ChiTietLapRapThaoDo chiTietLapRapThaoDo);
        void delete(int id);
        IEnumerable<ChiTietLapRapThaoDo> GetAll();
        ChiTietLapRapThaoDo GetByID(int id);
        IQueryable<getchitietlenhlaprapthaodo> getchitietlenhlaprapthaodo(string MaLapRapThaoDo);
        void Commit();
        void Save();

    }
    public class ChiTietLapRapThaoDoService : IChiTietLapRapThaoDoService
    {
        IChiTietLapRapThaoDoRepository _chiTietLapRapThaoDoRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietLapRapThaoDoService(IChiTietLapRapThaoDoRepository chiTietLapRapThaoDoRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietLapRapThaoDoRepository = chiTietLapRapThaoDoRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietLapRapThaoDo chiTietLapRapThaoDo)
        {
            _chiTietLapRapThaoDoRepository.Add(chiTietLapRapThaoDo);
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
            _chiTietLapRapThaoDoRepository.Delete(id);
        }

        public IEnumerable<ChiTietLapRapThaoDo> GetAll()
        {
            return _chiTietLapRapThaoDoRepository.GetAll();
        }

        public ChiTietLapRapThaoDo GetByID(int id)
        {
            return _chiTietLapRapThaoDoRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietLapRapThaoDo chiTietLapRapThaoDo)
        {
            _chiTietLapRapThaoDoRepository.Update(chiTietLapRapThaoDo);
        }

        public IQueryable<getchitietlenhlaprapthaodo> getchitietlenhlaprapthaodo(string MaLapRapThaoDo)
        {
            return _chiTietLapRapThaoDoRepository.getchitietlenhlaprapthaodo(MaLapRapThaoDo);
        }
    }
}
