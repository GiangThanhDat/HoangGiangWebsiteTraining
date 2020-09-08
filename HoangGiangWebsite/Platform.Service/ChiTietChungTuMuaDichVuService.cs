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
    public interface IChiTietChungTuMuaDichVuService
    {
        void Add(ChiTietChungTuMuaDichVu chiTietChungTuMuaDichVu);
        void Update(ChiTietChungTuMuaDichVu chiTietChungTuMuaDichVu);
        void delete(int id);
        IEnumerable<ChiTietChungTuMuaDichVu> GetAll();
        ChiTietChungTuMuaDichVu GetByID(int id);
        IEnumerable<getchungtumuadichvu> getchitietchungtumuadichvu(string machungtu);

        void Commit();
        void Save();

    }
    public class ChiTietChungTuMuaDichVuService : IChiTietChungTuMuaDichVuService
    {
        IChiTietChungTuMuaDichVuRepository _chiTietChungTuMuaDichVuRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietChungTuMuaDichVuService(IChiTietChungTuMuaDichVuRepository chiTietChungTuMuaDichVuRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietChungTuMuaDichVuRepository = chiTietChungTuMuaDichVuRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietChungTuMuaDichVu chiTietChungTuMuaDichVu)
        {
            _chiTietChungTuMuaDichVuRepository.Add(chiTietChungTuMuaDichVu);
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
            _chiTietChungTuMuaDichVuRepository.Delete(id);
        }

        public IEnumerable<ChiTietChungTuMuaDichVu> GetAll()
        {
            return _chiTietChungTuMuaDichVuRepository.GetAll();
        }

        public ChiTietChungTuMuaDichVu GetByID(int id)
        {
            return _chiTietChungTuMuaDichVuRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietChungTuMuaDichVu chiTietChungTuMuaDichVu)
        {
            _chiTietChungTuMuaDichVuRepository.Update(chiTietChungTuMuaDichVu);
        }

        public IEnumerable<getchungtumuadichvu> getchitietchungtumuadichvu(string machungtu)
        {
           return _chiTietChungTuMuaDichVuRepository.getchitietchungtumuadichvu(machungtu);
        }
    }
}
