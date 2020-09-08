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
    public interface ILenhSanXuat_ThanhPhamService
    {
        void Add(LenhSanXuat_ThanhPham lenhSanXuat_ThanhPham);
        void Update(LenhSanXuat_ThanhPham lenhSanXuat_ThanhPham);
        void delete(int id);
        IEnumerable<LenhSanXuat_ThanhPham> GetAll();
        LenhSanXuat_ThanhPham GetByID(int id);
        IQueryable<getchitietlenhsanxuatthanhpham> getchitietlenhsanxuatthanhpham(string MaLenhSanXuat);
        void Commit();
        void Save();

    }
    public class LenhSanXuat_ThanhPhamService : ILenhSanXuat_ThanhPhamService
    {
        ILenhSanXuat_ThanhPhamRepository _lenhSanXuat_ThanhPhamRepository;
        IUnitOfWork _unitOfWork;
        public LenhSanXuat_ThanhPhamService(ILenhSanXuat_ThanhPhamRepository lenhSanXuat_ThanhPhamRepository, IUnitOfWork unitOfWork)
        {
            this._lenhSanXuat_ThanhPhamRepository = lenhSanXuat_ThanhPhamRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(LenhSanXuat_ThanhPham lenhSanXuat_ThanhPham)
        {
            _lenhSanXuat_ThanhPhamRepository.Add(lenhSanXuat_ThanhPham);
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
            _lenhSanXuat_ThanhPhamRepository.Delete(id);
        }

        public IEnumerable<LenhSanXuat_ThanhPham> GetAll()
        {
            return _lenhSanXuat_ThanhPhamRepository.GetAll();
        }

        public LenhSanXuat_ThanhPham GetByID(int id)
        {
            return _lenhSanXuat_ThanhPhamRepository.GetSingleById(id);
        }

       

        public void Update(LenhSanXuat_ThanhPham lenhSanXuat_ThanhPham)
        {
            _lenhSanXuat_ThanhPhamRepository.Update(lenhSanXuat_ThanhPham);
        }

        public IQueryable<getchitietlenhsanxuatthanhpham> getchitietlenhsanxuatthanhpham(string MaLenhSanXuat)
        {
            return _lenhSanXuat_ThanhPhamRepository.getchitietlenhsanxuatthanhpham(MaLenhSanXuat);
        }
    }
}
