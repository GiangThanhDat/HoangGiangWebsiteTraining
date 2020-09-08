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
    public interface ITinhChatHangHoaService
    {
        void Add(TinhChatHangHoa tinhChatHangHoa);
        void Update(TinhChatHangHoa tinhChatHangHoa);
        void delete(int id);
        IEnumerable<TinhChatHangHoa> GetAll();
        TinhChatHangHoa GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class TinhChatHangHoaService : ITinhChatHangHoaService
    {
        ITinhChatHangHoaRepository _tinhChatHangHoaRepository;
        IUnitOfWork _unitOfWork;
        public TinhChatHangHoaService(ITinhChatHangHoaRepository tinhChatHangHoaRepository, IUnitOfWork unitOfWork)
        {
            this._tinhChatHangHoaRepository = tinhChatHangHoaRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(TinhChatHangHoa tinhChatHangHoa)
        {
            _tinhChatHangHoaRepository.Add(tinhChatHangHoa);
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
            _tinhChatHangHoaRepository.Delete(id);
        }

        public IEnumerable<TinhChatHangHoa> GetAll()
        {
            return _tinhChatHangHoaRepository.GetAll();
        }

        public TinhChatHangHoa GetByID(int id)
        {
            return _tinhChatHangHoaRepository.GetSingleById(id);
        }

       

        public void Update(TinhChatHangHoa tinhChatHangHoa)
        {
            _tinhChatHangHoaRepository.Update(tinhChatHangHoa);
        }

       
    }
}
