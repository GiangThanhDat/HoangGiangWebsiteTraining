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
    public interface IChiTietThuService
    {
        void Add(ChiTietThu chiTietThu);
        void Update(ChiTietThu chiTietThu);
        void delete(int id);
        IEnumerable<ChiTietThu> GetAll();
        ChiTietThu GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class ChiTietThuService : IChiTietThuService
    {
        IChiTietThuRepository _chiTietThuRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietThuService(IChiTietThuRepository chiTietThuRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietThuRepository = chiTietThuRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietThu chiTietThu)
        {
            _chiTietThuRepository.Add(chiTietThu);
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
            _chiTietThuRepository.Delete(id);
        }

        public IEnumerable<ChiTietThu> GetAll()
        {
            return _chiTietThuRepository.GetAll();
        }

        public ChiTietThu GetByID(int id)
        {
            return _chiTietThuRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietThu chiTietThu)
        {
            _chiTietThuRepository.Update(chiTietThu);
        }

       
    }
}
