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
    public interface IQuetTheService
    {
        void Add(QuetThe quetThe);
        void Update(QuetThe quetThe);
        void delete(int id);
        IEnumerable<QuetThe> GetAll();
        QuetThe GetByID(int id);
       
        void Commit();
        void Save();


    }
    public class QuetTheService : IQuetTheService
    {
        IQuetTheRepository _quetTheRepository;
        IUnitOfWork _unitOfWork;
        public QuetTheService(IQuetTheRepository quetTheRepository, IUnitOfWork unitOfWork)
        {
            this._quetTheRepository = quetTheRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(QuetThe quetThe)
        {
            _quetTheRepository.Add(quetThe);
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
            _quetTheRepository.Delete(id);
        }

        public IEnumerable<QuetThe> GetAll()
        {
            return _quetTheRepository.GetAll();
        }

        public QuetThe GetByID(int id)
        {
            return _quetTheRepository.GetSingleById(id);
        }

       

        public void Update(QuetThe quetThe)
        {
            _quetTheRepository.Update(quetThe);
        }
    }
}
