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
    public interface IHangHoaService
    {
        void Add(HangHoa hangHoa);
        void Update(HangHoa hangHoa);
        void delete(int id);
        IEnumerable<HangHoa> GetAll();
        HangHoa GetByID(int id);
        HangHoa GetByID(string id);
        IEnumerable<lichsutongquan> getlichsu();

        void Commit();
        void Save();

    }
    public class HangHoaService : IHangHoaService
    {
        IHangHoaRepository _hangHoaRepository;
        IUnitOfWork _unitOfWork;
        public HangHoaService(IHangHoaRepository hangHoaRepository, IUnitOfWork unitOfWork)
        {
            this._hangHoaRepository = hangHoaRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(HangHoa hangHoa)
        {
            _hangHoaRepository.Add(hangHoa);
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
            _hangHoaRepository.Delete(id);
        }

        public IEnumerable<HangHoa> GetAll()
        {
            return _hangHoaRepository.GetAll();
        }

        public HangHoa GetByID(int id)
        {
            return _hangHoaRepository.GetSingleById(id);
        }

       

        public void Update(HangHoa hangHoa)
        {
            _hangHoaRepository.Update(hangHoa);
        }

        public HangHoa GetByID(string id)
        {
            return _hangHoaRepository.GetSingleByCondition(x => x.MaHang==id);
        }

        public IEnumerable<lichsutongquan> getlichsu()
        {
            return _hangHoaRepository.getlichsu();
        }
    }
}
