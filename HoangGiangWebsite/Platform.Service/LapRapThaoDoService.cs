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
    public interface ILapRapThaoDoService
    {
        void Add(LapRapThaoDo lapRapThaoDo);
        void Update(LapRapThaoDo lapRapThaoDo);
        void delete(int id);
        IEnumerable<LapRapThaoDo> GetAll();
        LapRapThaoDo GetByID(int id);
        IQueryable<getlenhlaprapthaodo> getlenhlaprapthaodo(DateTime ngaydau, DateTime ngaycuoi);
        void Commit();
        void Save();

    }
    public class LapRapThaoDoService : ILapRapThaoDoService
    {
        ILapRapThaoDoRepository _lapRapThaoDoRepository;
        IUnitOfWork _unitOfWork;
        public LapRapThaoDoService(ILapRapThaoDoRepository lapRapThaoDoRepository, IUnitOfWork unitOfWork)
        {
            this._lapRapThaoDoRepository = lapRapThaoDoRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(LapRapThaoDo lapRapThaoDo)
        {
            _lapRapThaoDoRepository.Add(lapRapThaoDo);
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
            _lapRapThaoDoRepository.Delete(id);
        }

        public IEnumerable<LapRapThaoDo> GetAll()
        {
            return _lapRapThaoDoRepository.GetAll();
        }

        public LapRapThaoDo GetByID(int id)
        {
            return _lapRapThaoDoRepository.GetSingleById(id);
        }

       

        public void Update(LapRapThaoDo lapRapThaoDo)
        {
            _lapRapThaoDoRepository.Update(lapRapThaoDo);
        }

        public IQueryable<getlenhlaprapthaodo> getlenhlaprapthaodo(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _lapRapThaoDoRepository.getlenhlaprapthaodo(ngaydau, ngaycuoi);
        }
    }
}
