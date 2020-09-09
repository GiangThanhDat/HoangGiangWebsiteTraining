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
    public interface IChungTuMuaDichVuService
    {
        void Add(ChungTuMuaDichVu chungTuMuaDichVu);
        void Update(ChungTuMuaDichVu chungTuMuaDichVu);
        void delete(int id);
        IEnumerable<ChungTuMuaDichVu> GetAll();
        ChungTuMuaDichVu GetByID(int id);
        IEnumerable<getchungtumuadichvu> getchungtumuadichvu(DateTime ngaydau, DateTime ngaycuoi);

        void Commit();
        void Save();

    }
    public class ChungTuMuaDichVuService : IChungTuMuaDichVuService
    {
        IChungTuMuaDichVuRepository _chungTuMuaDichVuRepository;
        IUnitOfWork _unitOfWork;
        public ChungTuMuaDichVuService(IChungTuMuaDichVuRepository chungTuMuaDichVuRepository, IUnitOfWork unitOfWork)
        {
            this._chungTuMuaDichVuRepository = chungTuMuaDichVuRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChungTuMuaDichVu chungTuMuaDichVu)
        {
            _chungTuMuaDichVuRepository.Add(chungTuMuaDichVu);
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
            _chungTuMuaDichVuRepository.Delete(id);
        }

        public IEnumerable<ChungTuMuaDichVu> GetAll()
        {
            return _chungTuMuaDichVuRepository.GetAll();
        }

        public ChungTuMuaDichVu GetByID(int id)
        {
            return _chungTuMuaDichVuRepository.GetSingleById(id);
        }

       

        public void Update(ChungTuMuaDichVu chungTuMuaDichVu)
        {
            _chungTuMuaDichVuRepository.Update(chungTuMuaDichVu);
        }

        public IEnumerable<getchungtumuadichvu> getchungtumuadichvu(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _chungTuMuaDichVuRepository.getchungtumuadichvu(ngaydau, ngaycuoi);    
        }
    }
}
