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
    public interface ICoCauTocChucService
    {
        void Add(CoCauToChuc coCauToChuc);
        void Update(CoCauToChuc coCauToChuc);
        void delete(int id);
        IEnumerable<CoCauToChuc> GetAll();
        CoCauToChuc getID(string id);


        CoCauToChuc GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class CoCauTocChucService : ICoCauTocChucService
    {
        ICoCauTocChucRepository _coCauToChucRepository;
        IUnitOfWork _unitOfWork;
        public CoCauTocChucService(ICoCauTocChucRepository CoCauTocChucRepository, IUnitOfWork unitOfWork)
        {
            this._coCauToChucRepository = CoCauTocChucRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(CoCauToChuc coCauToChuc)
        {
            _coCauToChucRepository.Add(coCauToChuc);
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
            _coCauToChucRepository.Delete(id);
        }

        public IEnumerable<CoCauToChuc> GetAll()
        {
            return _coCauToChucRepository.GetAll();
        }

        public CoCauToChuc GetByID(int id)
        {
            return _coCauToChucRepository.GetSingleById(id);
        }

       

        public void Update(CoCauToChuc coCauToChuc)
        {
            _coCauToChucRepository.Update(coCauToChuc);
        }

        public CoCauToChuc getID(string id)
        {
            return _coCauToChucRepository.GetSingleById(id);
        }
    }
}
