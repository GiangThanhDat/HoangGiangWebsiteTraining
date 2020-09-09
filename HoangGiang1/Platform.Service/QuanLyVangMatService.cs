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
    public interface IQuanLyVangMatService
    {
        void Add(QuanLyVangMat quanLyVangMat);
        void Update(QuanLyVangMat quanLyVangMat);
        void delete(int id);
        IEnumerable<QuanLyVangMat> GetAll();
        QuanLyVangMat GetByID(int id);
        IEnumerable<NhanVienVangMat> xemtheongay(DateTime ngay);
        IEnumerable<NhanVienVangMat> xemtheomsnv(string msnv);
        IEnumerable<NhanVienVangMat> xemtheotennv(string tennv);
        IEnumerable<NhanVienVangMat> getall();

        IEnumerable<QuanLyVangMat> quanLyVangMat(string msnv);

        void Commit();
        void Save();


    }
    public class QuanLyVangMatService : IQuanLyVangMatService
    {
        IQuanLyVangMatRepository _quanLyVangMatRepository;
        IUnitOfWork _unitOfWork;
        public QuanLyVangMatService(IQuanLyVangMatRepository quanLyVangMatRepository, IUnitOfWork unitOfWork)
        {
            this._quanLyVangMatRepository = quanLyVangMatRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(QuanLyVangMat quanLyVangMat)
        {
            _quanLyVangMatRepository.Add(quanLyVangMat);
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
            _quanLyVangMatRepository.Delete(id);
        }

        public IEnumerable<QuanLyVangMat> GetAll()
        {
            return _quanLyVangMatRepository.GetAll();
        }

        public QuanLyVangMat GetByID(int id)
        {
            return _quanLyVangMatRepository.GetSingleById(id);
        }

        

        public void Update(QuanLyVangMat quanLyVangMat)
        {
            _quanLyVangMatRepository.Update(quanLyVangMat);
        }

        public IEnumerable<NhanVienVangMat> xemtheongay(DateTime ngay)
        {
           return _quanLyVangMatRepository.xemtheongay(ngay);
        }

        public IEnumerable<NhanVienVangMat> xemtheomsnv(string msnv)
        {
            return _quanLyVangMatRepository.xemtheomsnv(msnv);
        }

        public IEnumerable<NhanVienVangMat> xemtheotennv(string tennv)
        {
            return _quanLyVangMatRepository.xemtheotennv(tennv);
        }

        public IEnumerable<NhanVienVangMat> getall()
        {
            return _quanLyVangMatRepository.getall();
        }

        public IEnumerable<QuanLyVangMat> quanLyVangMat(string msnv)
        {
            return _quanLyVangMatRepository.quanLyVangMat(msnv);
        }
    }
}
