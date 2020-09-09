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
    public interface IChiTietBaoGiaService
    {
        void Add(ChiTietBaoGia chiTietBaoGia);
        void Update(ChiTietBaoGia chiTietBaoGia);
        void delete(int id);
        IEnumerable<ChiTietBaoGia> GetAll();
        IEnumerable<ChiTietBaoGia> getbyid(string id);
        IQueryable<getchitietbaogia> getchitietbaogia(string MaBG);

        ChiTietBaoGia GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class ChiTietBaoGiaService : IChiTietBaoGiaService
    {
        IChiTietBaoGiaRepository _chiTietBaoGiaRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietBaoGiaService(IChiTietBaoGiaRepository chiTietBaoGiaRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietBaoGiaRepository = chiTietBaoGiaRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietBaoGia chiTietBaoGia)
        {
            _chiTietBaoGiaRepository.Add(chiTietBaoGia);
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
            _chiTietBaoGiaRepository.Delete(id);
        }

        public IEnumerable<ChiTietBaoGia> GetAll()
        {
            return _chiTietBaoGiaRepository.GetAll();
        }

        public ChiTietBaoGia GetByID(int id)
        {
            return _chiTietBaoGiaRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietBaoGia chiTietBaoGia)
        {
            _chiTietBaoGiaRepository.Update(chiTietBaoGia);
        }

        public IEnumerable<ChiTietBaoGia> getbyid(string id)
        {
            return _chiTietBaoGiaRepository.GetMulti(x => x.MaSoBaoGia == id);
        }

        public IQueryable<getchitietbaogia> getchitietbaogia(string MaBG)
        {
            return _chiTietBaoGiaRepository.getchitietbaogia(MaBG);
        }
    }
}
