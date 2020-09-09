

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
    public interface IQuanLyNhaCungCapService
    {
        void Add(NhaCungCap nhaCungCap);
        void Update(NhaCungCap nhaCungCap);
        void delete(int id);
        IEnumerable<NhaCungCap> GetAll();
        NhaCungCap GetByID(int id);
        NhaCungCap getThongTinNhaCungCap(string name);
       IEnumerable< NhaCungCap >search(string name);
        void Commit();
        void Save();
     

    }
    public class QuanLyNhaCungCapService : IQuanLyNhaCungCapService
    {
        IQuanLyNhaCungCapRepository _quanLyNhaCungCapRepository;
        IUnitOfWork _unitOfWork;
        public QuanLyNhaCungCapService(IQuanLyNhaCungCapRepository quanLyNhaCungCapRepository, IUnitOfWork unitOfWork)
        {
            this._quanLyNhaCungCapRepository = quanLyNhaCungCapRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(NhaCungCap nhaCungCap)
        {
            _quanLyNhaCungCapRepository.Add(nhaCungCap);
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
            _quanLyNhaCungCapRepository.Delete(id);
        }

        public IEnumerable<NhaCungCap> GetAll()
        {
            return _quanLyNhaCungCapRepository.GetAll();
        }

        public NhaCungCap GetByID(int id)
        {
            return _quanLyNhaCungCapRepository.GetSingleById(id);
        }



        public void Update(NhaCungCap nhaCungCap)
        {
            _quanLyNhaCungCapRepository.Update(nhaCungCap);
        }

        public NhaCungCap getThongTinNhaCungCap(string name)
        {
            return _quanLyNhaCungCapRepository.getThongTinNhaCungCap(name);
        }

        public IEnumerable< NhaCungCap> search(string name)
        {
            return _quanLyNhaCungCapRepository.GetMulti(x=>x.TenNhaCungCap.Contains(name)|| x.DiaChi.Contains(name));
        }
    }
}
