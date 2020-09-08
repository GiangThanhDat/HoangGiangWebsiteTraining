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
    public interface IHangHoa_DonViTinhService
    {
        void Add(HangHoa_DonViTinh hangHoa_DonViTinh);
        void Update(HangHoa_DonViTinh hangHoa_DonViTinh);
        void delete(int id);
        IEnumerable<HangHoa_DonViTinh> GetAll();
        HangHoa_DonViTinh GetByID(int id);
        IEnumerable<getdvt> getdvt(string mahang);

        void Commit();
        void Save();

    }
    public class HangHoa_DonViTinhService : IHangHoa_DonViTinhService
    {
        IHangHoa_DonViTinhRepository _hangHoa_DonViTinhRepository;
        IUnitOfWork _unitOfWork;
        public HangHoa_DonViTinhService(IHangHoa_DonViTinhRepository hangHoa_DonViTinhRepository, IUnitOfWork unitOfWork)
        {
            this._hangHoa_DonViTinhRepository = hangHoa_DonViTinhRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(HangHoa_DonViTinh hangHoa_DonViTinh)
        {
            _hangHoa_DonViTinhRepository.Add(hangHoa_DonViTinh);
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
            _hangHoa_DonViTinhRepository.Delete(id);
        }

        public IEnumerable<HangHoa_DonViTinh> GetAll()
        {
            return _hangHoa_DonViTinhRepository.GetAll();
        }

        public HangHoa_DonViTinh GetByID(int id)
        {
            return _hangHoa_DonViTinhRepository.GetSingleById(id);
        }

       

        public void Update(HangHoa_DonViTinh hangHoa_DonViTinh)
        {
            _hangHoa_DonViTinhRepository.Update(hangHoa_DonViTinh);
        }

       

        public IEnumerable<getdvt> getdvt(string mahang)
        {
            return _hangHoa_DonViTinhRepository.getdvt(mahang);
        }
    }
}
