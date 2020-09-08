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
    public interface IQuanLyTaiSanService
    {
        void Add(QuanLyTaiSan quanLyTaiSan);
        void Update(QuanLyTaiSan quanLyTaiSan);
        void delete(int id);
        IEnumerable<QuanLyTaiSan> GetAll();
        QuanLyTaiSan GetByID(int id);
        IQueryable<getQuanLyTaiSanCaNhan> getQuanLyTaiSanCaNhan(string msnv);
        void Commit();
        void Save();


    }
    public class QuanLyTaiSanService : IQuanLyTaiSanService
    {
        IQuanLyTaiSanRepository _quanLyTaiSanRepository;
        IUnitOfWork _unitOfWork;
        public QuanLyTaiSanService(IQuanLyTaiSanRepository quanLyTaiSanRepository, IUnitOfWork unitOfWork)
        {
            this._quanLyTaiSanRepository = quanLyTaiSanRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(QuanLyTaiSan quanLyTaiSan)
        {
            _quanLyTaiSanRepository.Add(quanLyTaiSan);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _quanLyTaiSanRepository.Delete(id);
        }

        public IEnumerable<QuanLyTaiSan> GetAll()
        {
            return _quanLyTaiSanRepository.GetAll();
        }

        public QuanLyTaiSan GetByID(int id)
        {
            return _quanLyTaiSanRepository.GetSingleById(id);
        }


        public void Update(QuanLyTaiSan quanLyTaiSan)
        {
            _quanLyTaiSanRepository.Update(quanLyTaiSan);
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<getQuanLyTaiSanCaNhan> getQuanLyTaiSanCaNhan(string msnv)
        {
            return _quanLyTaiSanRepository.getQuanLyTaiSanCaNhan(msnv);
        }
    }
}
