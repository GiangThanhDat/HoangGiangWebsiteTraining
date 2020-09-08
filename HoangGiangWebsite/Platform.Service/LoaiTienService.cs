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
    public interface ILoaiTienService
    {
        void Add(LoaiTien loaiTien);
        void Update(LoaiTien loaiTien);
        void delete(int id);
        IEnumerable<LoaiTien> GetAll();
        LoaiTien GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class LoaiTienService : ILoaiTienService
    {
        ILoaiTienRepository _loaiTienRepository;
        IUnitOfWork _unitOfWork;
        public LoaiTienService(ILoaiTienRepository loaiTienRepository, IUnitOfWork unitOfWork)
        {
            this._loaiTienRepository = loaiTienRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(LoaiTien loaiTien)
        {
            _loaiTienRepository.Add(loaiTien);
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
            _loaiTienRepository.Delete(id);
        }

        public IEnumerable<LoaiTien> GetAll()
        {
            return _loaiTienRepository.GetAll();
        }

        public LoaiTien GetByID(int id)
        {
            return _loaiTienRepository.GetSingleById(id);
        }

       

        public void Update(LoaiTien loaiTien)
        {
            _loaiTienRepository.Update(loaiTien);
        }

       
    }
}
