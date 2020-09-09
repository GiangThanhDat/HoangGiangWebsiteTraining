using Platform.Data.Infrastructure;
using Platform.Data.Repositories;
using Platform.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface ITheService
    {
        void Add(The the);
        void Update(The the);
        void delete(int id);
        IEnumerable<The> GetAll();
        The GetByID(int id);
        IEnumerable<The> the(string msnv);
        IQueryable<gettennhanvienthe> gettennhanvienthe();
        IQueryable<The> searchs(string name);
        IEnumerable<The> search(string name);
        void Commit();
        void Save();
        The getID(int ID);

        The DELETE(int id);

    }
    public class TheService : ITheService
    {
        ITheRepository _theRepository;
        INhanVienRepository _nhanVienRepository;
        IUnitOfWork _unitOfWork;
        public TheService(ITheRepository theRepository, INhanVienRepository nhanVienRepository, IUnitOfWork unitOfWork)
        {
            this._theRepository = theRepository;
            this._nhanVienRepository = nhanVienRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(The the)
        {
            _theRepository.Add(the);
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
            _theRepository.Delete(id);
        }

        public IEnumerable<The> GetAll()
        {
            return _theRepository.GetAll();
        }

        public The GetByID(int id)
        {
            return _theRepository.GetSingleById(id);
        }

       

        public void Update(The the)
        {
            _theRepository.Update(the);
        }

        public IEnumerable<The> the(string msnv)
        {
            return _theRepository.the(msnv);
        }

        public The getID(int ID)
        {
            return _theRepository.getID(ID);
        }

        public IEnumerable<The> search(string name)
        {
            
            //var nhanvien = _nhanVienRepository.GetMulti(x => x.HoVaTen.Contains(name));
          
            return _theRepository.GetMulti(x => x.MaSoNhanVien.Contains(name) || x.LoaiThe.Contains(name));
        }

        public IQueryable<gettennhanvienthe> gettennhanvienthe()
        {
            return _theRepository.gettennhanvienthe();
        }

        public IQueryable<The> searchs(string name)
        {
            return _theRepository.searchs(name);
        }

        public The DELETE(int id)
        {
            return _theRepository.Delete(id);
        }
    }
}
