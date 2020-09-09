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
    public interface IDonViTinhService
    {
        void Add(DonViTinh donViTinh);
        void Update(DonViTinh donViTinh);
        void delete(int id);
        IEnumerable<DonViTinh> GetAll();
        DonViTinh GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class DonViTinhService : IDonViTinhService
    {
        IDonViTinhRepository _donViTinhRepository;
        IUnitOfWork _unitOfWork;
        public DonViTinhService(IDonViTinhRepository donViTinhRepository, IUnitOfWork unitOfWork)
        {
            this._donViTinhRepository = donViTinhRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(DonViTinh donViTinh)
        {
            _donViTinhRepository.Add(donViTinh);
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
            _donViTinhRepository.Delete(id);
        }

        public IEnumerable<DonViTinh> GetAll()
        {
            return _donViTinhRepository.GetAll();
        }

        public DonViTinh GetByID(int id)
        {
            return _donViTinhRepository.GetSingleById(id);
        }

       

        public void Update(DonViTinh donViTinh)
        {
            _donViTinhRepository.Update(donViTinh);
        }

       
    }
}
