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
    public interface IThanhPhamService
    {
        void Add(ThanhPham thanhPham);
        void Update(ThanhPham thanhPham);
        void delete(int id);
        IEnumerable<ThanhPham> GetAll();
        ThanhPham GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class ThanhPhamService : IThanhPhamService
    {
        IThanhPhamRepository _thanhPhamRepository;
        IUnitOfWork _unitOfWork;
        public ThanhPhamService(IThanhPhamRepository thanhPhamRepository, IUnitOfWork unitOfWork)
        {
            this._thanhPhamRepository = thanhPhamRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ThanhPham thanhPham)
        {
            _thanhPhamRepository.Add(thanhPham);
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
            _thanhPhamRepository.Delete(id);
        }

        public IEnumerable<ThanhPham> GetAll()
        {
            return _thanhPhamRepository.GetAll();
        }

        public ThanhPham GetByID(int id)
        {
            return _thanhPhamRepository.GetSingleById(id);
        }

       

        public void Update(ThanhPham thanhPham)
        {
            _thanhPhamRepository.Update(thanhPham);
        }

       
    }
}
