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
    public interface INgonNguService
    {
        void Add(NgonNgu ngonNgu);
        void Update(NgonNgu ngonNgu);
        void delete(int id);
        NgonNgu DELETE(int ID);
        IEnumerable<NgonNgu> GetAll();
        NgonNgu GetByID(int id);
        IEnumerable<NgonNgu> ngonNgu(string msnv);
        void Commit();
        void Save();
        NgonNgu getID(int ID);


    }
    public class NgonNguService : INgonNguService
    {
        INgonNguRepository _ngonNguRepository;
        IUnitOfWork _unitOfWork;
    public NgonNguService(INgonNguRepository ngonNguRepository, IUnitOfWork unitOfWork)
        {
            this._ngonNguRepository = ngonNguRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(NgonNgu ngonNgu)
        {
            _ngonNguRepository.Add(ngonNgu);
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
            _ngonNguRepository.Delete(id);
        }

        public IEnumerable<NgonNgu> GetAll()
        {
            return _ngonNguRepository.GetAll();
        }

        public NgonNgu GetByID(int id)
        {
            return _ngonNguRepository.GetSingleById(id);
        }

       

        public void Update(NgonNgu ngonNgu)
        {
            _ngonNguRepository.Update(ngonNgu);
        }

        public IEnumerable<NgonNgu> ngonNgu(string msnv)
        {
            return _ngonNguRepository.ngonNgu(msnv);
        }

        public NgonNgu getID(int ID)
        {
            return _ngonNguRepository.getID(ID);
        }

        public NgonNgu DELETE(int ID)
        {
            return _ngonNguRepository.Delete(ID);
        }
    }
}
