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
    public interface IQuanLyNgayNghiService
    {
        void Add(QuanLyNgayNghi quanLyNgayNghi);
        void Update(QuanLyNgayNghi quanLyNgayNghi);
        void delete(int id);
        IEnumerable<QuanLyNgayNghi> GetAll();
        QuanLyNgayNghi GetByID(int id);
        IEnumerable<QuanLyNgayNghi> quanLyNgayNghi(string msnv);
        QuanLyNgayNghi getID(int ID);
        IEnumerable<getQuanLyNgayNghi> xemtheongay(DateTime ngay);
        IEnumerable<getQuanLyNgayNghi> xemtheomsnv(string msnv);
        IEnumerable<getQuanLyNgayNghi> xemtheotennv(string tennv);
        IEnumerable<getQuanLyNgayNghi> getall();
        void Commit();
        void Save();


    }
    public class QuanLyNgayNghiService : IQuanLyNgayNghiService
    {
        IQuanLyNgayNghiRepository _quanLyNgayNghiRepository;
        IUnitOfWork _unitOfWork;
        public QuanLyNgayNghiService(IQuanLyNgayNghiRepository quanLyNgayNghiRepository, IUnitOfWork unitOfWork)
        {
            this._quanLyNgayNghiRepository = quanLyNgayNghiRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(QuanLyNgayNghi quanLyNgayNghi)
        {
            _quanLyNgayNghiRepository.Add(quanLyNgayNghi);
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
            _quanLyNgayNghiRepository.Delete(id);
        }

        public IEnumerable<QuanLyNgayNghi> GetAll()
        {
            return _quanLyNgayNghiRepository.GetAll();
        }

        public QuanLyNgayNghi GetByID(int id)
        {
            return _quanLyNgayNghiRepository.GetSingleById(id);
        }

      
        public void Update(QuanLyNgayNghi quanLyNgayNghi)
        {
            _quanLyNgayNghiRepository.Update(quanLyNgayNghi);
        }

        public IEnumerable<QuanLyNgayNghi> quanLyNgayNghi(string msnv)
        {
            return _quanLyNgayNghiRepository.quanLyNgayNghi(msnv);
        }

        public QuanLyNgayNghi getID(int ID)
        {
            return _quanLyNgayNghiRepository.getID(ID);
        }

        public IEnumerable<getQuanLyNgayNghi> xemtheongay(DateTime ngay)
        {
            return _quanLyNgayNghiRepository.xemtheongay(ngay);
        }

        public IEnumerable<getQuanLyNgayNghi> xemtheomsnv(string msnv)
        {
            return _quanLyNgayNghiRepository.xemtheomsnv(msnv);
        }

        public IEnumerable<getQuanLyNgayNghi> xemtheotennv(string tennv)
        {
            return _quanLyNgayNghiRepository.xemtheotennv(tennv);
        }

        public IEnumerable<getQuanLyNgayNghi> getall()
        {
            return _quanLyNgayNghiRepository.getall();
        }
    }
    
}
