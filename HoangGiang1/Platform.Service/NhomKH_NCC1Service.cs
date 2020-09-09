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
    public interface INhomKH_NCC1Service
    {
        void Add(NhomKH_NCC1 nhomKH_NCC1);
        void Update(NhomKH_NCC1 nhomKH_NCC1);
        void delete(int id);
        NhomKH_NCC1 DELETE(int ID);
        IEnumerable<NhomKH_NCC1> GetAll(); 
        IEnumerable<NhomKH_NCC1> GetByKeyWord(string keyword);

        NhomKH_NCC1 GetByID(int id);
        NhomKH_NCC1 GetByID(string id);
       
        void Commit();
        void Save();


    }
    public class NhomKH_NCC1Service : INhomKH_NCC1Service
    {
        INhomKH_NCC1Repository _nhomKH_NCC1Repository;
        IUnitOfWork _unitOfWork;
        public NhomKH_NCC1Service(INhomKH_NCC1Repository nhomKH_NCC1Repository, IUnitOfWork unitOfWork)
        {
            this._nhomKH_NCC1Repository = nhomKH_NCC1Repository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(NhomKH_NCC1 nhomKH_NCC1)
        {
            _nhomKH_NCC1Repository.Add(nhomKH_NCC1);
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
            _nhomKH_NCC1Repository.Delete(id);
        }

        public IEnumerable<NhomKH_NCC1> GetAll()
        {
            return _nhomKH_NCC1Repository.GetAll();
        }

        public NhomKH_NCC1 GetByID(int id)
        {
            return _nhomKH_NCC1Repository.GetSingleById(id);
        }



        public void Update(NhomKH_NCC1 nhomKH_NCC1)
        {
            _nhomKH_NCC1Repository.Update(nhomKH_NCC1);
        }

       
      
        public NhomKH_NCC1 DELETE(int ID)
        {
            return _nhomKH_NCC1Repository.Delete(ID);
        }

        
        public NhomKH_NCC1 GetByID(string id)
        {
            return _nhomKH_NCC1Repository.GetSingleById(id);
        }

        public IEnumerable<NhomKH_NCC1> GetByKeyWord(string keyword)
        {
            return _nhomKH_NCC1Repository.GetMulti(x => x.NhomKH_NCC.Contains(keyword) || x.TenNhomKH_NCC.Contains(keyword));
        }
    }
}
