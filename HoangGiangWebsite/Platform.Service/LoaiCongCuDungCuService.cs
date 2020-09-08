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
    public interface ILoaiCongCuDungCuService
    {
        void Add(LoaiCongCuDungCu loaiCongCuDungCu);
        void Update(LoaiCongCuDungCu loaiCongCuDungCu);
        void delete(int id);
        IEnumerable<LoaiCongCuDungCu> GetAll();
        LoaiCongCuDungCu getID(string id);


        LoaiCongCuDungCu GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class LoaiCongCuDungCuService : ILoaiCongCuDungCuService
    {
        ILoaiCongCuDungCuRepository _loaiCongCuDungCuRepository;
        IUnitOfWork _unitOfWork;
        public LoaiCongCuDungCuService(ILoaiCongCuDungCuRepository chiTietChungTuBanHangRepository, IUnitOfWork unitOfWork)
        {
            this._loaiCongCuDungCuRepository = chiTietChungTuBanHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(LoaiCongCuDungCu loaiCongCuDungCu)
        {
            _loaiCongCuDungCuRepository.Add(loaiCongCuDungCu);
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
            _loaiCongCuDungCuRepository.Delete(id);
        }

        public IEnumerable<LoaiCongCuDungCu> GetAll()
        {
            return _loaiCongCuDungCuRepository.GetAll();
        }

        public LoaiCongCuDungCu GetByID(int id)
        {
            return _loaiCongCuDungCuRepository.GetSingleById(id);
        }

       

        public void Update(LoaiCongCuDungCu loaiCongCuDungCu)
        {
            _loaiCongCuDungCuRepository.Update(loaiCongCuDungCu);
        }

        public LoaiCongCuDungCu getID(string id)
        {
            return _loaiCongCuDungCuRepository.GetSingleById(id);
        }
    }
}
