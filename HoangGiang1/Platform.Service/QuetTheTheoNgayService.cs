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
    public interface IQuetTheTheoNgayService
    {
        void Add(QuetTheTheoNgay quetTheTheoNgay);
        void Update(QuetTheTheoNgay quetTheTheoNgay);
        void delete(int id);
        IEnumerable<QuetTheTheoNgay> GetAll();
        QuetTheTheoNgay GetByID(int id);
        QuetTheTheoNgay GetByMaNV(string id);
       
        void Commit();
        void Save();


    }
    public class QuetTheTheoNgayService : IQuetTheTheoNgayService
    {
        IQuetTheTheoNgayRepository _quetTheTheoNgayRepository;
        IUnitOfWork _unitOfWork;
        public QuetTheTheoNgayService(IQuetTheTheoNgayRepository quetTheTheoNgayRepository, IUnitOfWork unitOfWork)
        {
            this._quetTheTheoNgayRepository = quetTheTheoNgayRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(QuetTheTheoNgay quetTheTheoNgay)
        {
            _quetTheTheoNgayRepository.Add(quetTheTheoNgay);
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
            _quetTheTheoNgayRepository.Delete(id);
        }

        public IEnumerable<QuetTheTheoNgay> GetAll()
        {
            return _quetTheTheoNgayRepository.GetAll();
        }

        public QuetTheTheoNgay GetByID(int id)
        {
            return _quetTheTheoNgayRepository.GetSingleById(id);
        }

       

        public void Update(QuetTheTheoNgay quetTheTheoNgay)
        {
            _quetTheTheoNgayRepository.Update(quetTheTheoNgay);
        }

        

        public QuetTheTheoNgay GetByMaNV(string id)
        {
           return _quetTheTheoNgayRepository.GetSingleByCondition(x => x.MaSoNhanVien == id);
        }
    }
}
