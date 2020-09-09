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
    public interface INhomHangHoaService
    {
        void Add(NhomHangHoa nhomHangHoa);
        void Update(NhomHangHoa nhomHangHoa);
        void delete(int id);
        IEnumerable<NhomHangHoa> GetAll();
        NhomHangHoa GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class NhomHangHoaService : INhomHangHoaService
    {
        INhomHangHoaRepository _nhomHangHoaRepository;
        IUnitOfWork _unitOfWork;
        public NhomHangHoaService(INhomHangHoaRepository nhomHangHoaRepository, IUnitOfWork unitOfWork)
        {
            this._nhomHangHoaRepository = nhomHangHoaRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(NhomHangHoa nhomHangHoa)
        {
            _nhomHangHoaRepository.Add(nhomHangHoa);
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
            _nhomHangHoaRepository.Delete(id);
        }

        public IEnumerable<NhomHangHoa> GetAll()
        {
            return _nhomHangHoaRepository.GetAll();
        }

        public NhomHangHoa GetByID(int id)
        {
            return _nhomHangHoaRepository.GetSingleById(id);
        }

       

        public void Update(NhomHangHoa nhomHangHoa)
        {
            _nhomHangHoaRepository.Update(nhomHangHoa);
        }

        
    }
}
