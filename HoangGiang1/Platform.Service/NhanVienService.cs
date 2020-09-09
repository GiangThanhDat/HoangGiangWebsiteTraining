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
    public interface INhanVienService
    {
        void Add(NhanVien nhanVien);
        void Update(NhanVien nhanVien);
        void delete(int id);
        IEnumerable<NhanVien> GetAll();
        NhanVien GetByID(int id);
        NhanVien GetLyLich(string msnv);
        IEnumerable<NhanVienVangMat> getbymsnv(string msnv);
        IEnumerable<NhanVien> search(string keyword);
        NhanVien nhanVien(string msnv);
        IQueryable<getnhanvien> getnhanvien();
        getChucVu getchucvu(string msnv);
       
        void Save();
    
        void Commit();

    }
    public class NhanVienService : INhanVienService
    {
        INhanVienRepository _nhanVienRepository;
        IUnitOfWork _unitOfWork;
        public NhanVienService(INhanVienRepository nhanVienRepository, IUnitOfWork unitOfWork)
        {
            this._nhanVienRepository = nhanVienRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(NhanVien nhanVien)
        {
            _nhanVienRepository.Add(nhanVien);
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
            _nhanVienRepository.Delete(id);
        }

        public IEnumerable<NhanVien> GetAll()
        {
            return _nhanVienRepository.GetAll();
        }

        public NhanVien GetByID(int id)
        {
            return _nhanVienRepository.GetSingleById(id);
        }

      
        public void Update(NhanVien nhanVien)
        {
            _nhanVienRepository.Update(nhanVien);
        }

        public NhanVien GetLyLich(string msnv)
        {
            return _nhanVienRepository.GetLyLich(msnv);
        }

        public IEnumerable<NhanVienVangMat> getbymsnv(string msnv)
        {
            return _nhanVienRepository.getbymsnv(msnv);
        }
        public NhanVien nhanVien(string msnv)
        {
            return _nhanVienRepository.nhanVien(msnv);
        }
        public IQueryable<getnhanvien> getnhanvien()
        {
            return _nhanVienRepository.getnhanvien();
        }
        public getChucVu getchucvu(string msnv)
        {
            return _nhanVienRepository.getchucvu(msnv);
        }

        public IEnumerable<NhanVien> search(string keyword)
        {
            return _nhanVienRepository.GetMulti(x => x.MaSoNhanVien.Contains(keyword) || x.HoVaTen.Contains(keyword));
        }
    }
}
