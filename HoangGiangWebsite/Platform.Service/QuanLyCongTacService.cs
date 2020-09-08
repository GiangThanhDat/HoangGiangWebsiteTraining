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
    public interface IQuanLyCongTacService
    {
        void Add(QuanLyCongTac quanLyCongTac);
        void Update(QuanLyCongTac quanLyCongTac);
        void delete(int id);
        IEnumerable<QuanLyCongTac> GetAll();
        QuanLyCongTac GetByID(int id);
        IEnumerable<QuanLyCongTac> quanLyCongTac(string msnv);
        void Commit();
        void Save(); 
        IEnumerable<getQuanLyCongTac> xemtheongay(DateTime ngay);
        IEnumerable<getQuanLyCongTac> xemtheomsnv(string msnv);
        IEnumerable<getQuanLyCongTac> xemtheotennv(string tennv);
        IEnumerable<getQuanLyCongTac> getall();
        QuanLyCongTac getID(int ID);


    }
    public class QuanLyCongTacService : IQuanLyCongTacService
    {
        IQuanLyCongTacRepository _quanLyCongTacRepository;
        IUnitOfWork _unitOfWork;
        public QuanLyCongTacService(IQuanLyCongTacRepository quanLyCongTacRepository, IUnitOfWork unitOfWork)
        {
            this._quanLyCongTacRepository = quanLyCongTacRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(QuanLyCongTac quanLyCongTac)
        {
            _quanLyCongTacRepository.Add(quanLyCongTac);
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
            _quanLyCongTacRepository.Delete(id);
        }

        public IEnumerable<QuanLyCongTac> GetAll()
        {
            return _quanLyCongTacRepository.GetAll();
        }

        public QuanLyCongTac GetByID(int id)
        {
            return _quanLyCongTacRepository.GetSingleById(id);
        }

       
        public void Update(QuanLyCongTac quanLyCongTac)
        {
            _quanLyCongTacRepository.Update(quanLyCongTac);
        }

        public IEnumerable<QuanLyCongTac> quanLyCongTac(string msnv)
        {
            return _quanLyCongTacRepository.quanLyCongTac(msnv);
        }

        public QuanLyCongTac getID(int ID)
        {
            return _quanLyCongTacRepository.getID(ID);
        }

        public IEnumerable<getQuanLyCongTac> xemtheongay(DateTime ngay)
        {
            return _quanLyCongTacRepository.xemtheongay(ngay);
        }

        public IEnumerable<getQuanLyCongTac> xemtheomsnv(string msnv)
        {
            return _quanLyCongTacRepository.xemtheomsnv(msnv);
        }

        public IEnumerable<getQuanLyCongTac> xemtheotennv(string tennv)
        {
            return _quanLyCongTacRepository.xemtheotennv(tennv);
        }
        public IEnumerable<getQuanLyCongTac> getall()
        {
            return _quanLyCongTacRepository.getall();
        }
    }
}
