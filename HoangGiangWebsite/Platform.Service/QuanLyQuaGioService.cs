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
    public interface IQuanLyQuaGioService
    {
        void Add(QuanLyQuaGio quanLyQuaGio);
        void Update(QuanLyQuaGio quanLyQuaGio);
        void delete(int id);
        IEnumerable<QuanLyQuaGio> GetAll();
        QuanLyQuaGio GetByID(int id);
        IEnumerable<QuanLyQuaGio> GetQuanLyQuaGio(string msnv);
        void Commit();
        void Save();
        QuanLyQuaGio getID(int ID);

    }
    public class QuanLyQuaGioService : IQuanLyQuaGioService
    {
        IQuanLyQuaGioRepository _quanLyQuaGioRepository;
        IUnitOfWork _unitOfWork;
        public QuanLyQuaGioService(IQuanLyQuaGioRepository quanLyQuaGioRepository, IUnitOfWork unitOfWork)
        {
            this._quanLyQuaGioRepository = quanLyQuaGioRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(QuanLyQuaGio quanLyQuaGio)
        {
            _quanLyQuaGioRepository.Add(quanLyQuaGio);
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
            _quanLyQuaGioRepository.Delete(id);
        }

        public IEnumerable<QuanLyQuaGio> GetAll()
        {
            return _quanLyQuaGioRepository.GetAll();
        }

        public QuanLyQuaGio GetByID(int id)
        {
            return _quanLyQuaGioRepository.GetSingleById(id);
        }

        

        public void Update(QuanLyQuaGio quanLyQuaGio)
        {
            _quanLyQuaGioRepository.Update(quanLyQuaGio);
        }

        public IEnumerable<QuanLyQuaGio> GetQuanLyQuaGio(string msnv)
        {
            return _quanLyQuaGioRepository.GetQuanLyQuaGio(msnv);
        }

        public QuanLyQuaGio getID(int ID)
        {
            return _quanLyQuaGioRepository.getID(ID);
        }
    }
}
