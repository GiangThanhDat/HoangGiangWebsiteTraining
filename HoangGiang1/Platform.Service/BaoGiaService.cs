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
    public interface IBaoGiaService
    {
        void Add(BaoGia baoGia);
        void Update(BaoGia baoGia);
        void delete(int id);
        IEnumerable<BaoGia> GetAll();
        BaoGia GetByID(int id);
        IQueryable<getbaogia> getbaogia(DateTime ngaydau, DateTime ngaycuoi);
        void Commit();
        void Save();

    }
    public class BaoGiaService : IBaoGiaService
    {
        IBaoGiaRepository _baoGiaRepository;
        IUnitOfWork _unitOfWork;
        public BaoGiaService(IBaoGiaRepository baoGiaRepository, IUnitOfWork unitOfWork)
        {
            this._baoGiaRepository = baoGiaRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(BaoGia baoGia)
        {
            _baoGiaRepository.Add(baoGia);
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
            _baoGiaRepository.Delete(id);
        }

        public IEnumerable<BaoGia> GetAll()
        {
            return _baoGiaRepository.GetAll();
        }

        public BaoGia GetByID(int id)
        {
            return _baoGiaRepository.GetSingleById(id);
        }



        public void Update(BaoGia baoGia)
        {
            _baoGiaRepository.Update(baoGia);
        }

        public IQueryable<getbaogia> getbaogia(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _baoGiaRepository.getbaogia(ngaydau, ngaycuoi);
        }
    }
}