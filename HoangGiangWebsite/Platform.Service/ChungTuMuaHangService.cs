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
    public interface IChungTuMuaHangService
    {
        void Add(ChungTuMuaHang chungTuMuaHang);
        void Update(ChungTuMuaHang chungTuMuaHang);
        void delete(int id);
        IEnumerable<ChungTuMuaHang> GetAll();
        ChungTuMuaHang GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class ChungTuMuaHangService : IChungTuMuaHangService
    {
        IChungTuMuaHangRepository _chungTuMuaHangRepository;
        IUnitOfWork _unitOfWork;
        public ChungTuMuaHangService(IChungTuMuaHangRepository chungTuMuaHangRepository, IUnitOfWork unitOfWork)
        {
            this._chungTuMuaHangRepository = chungTuMuaHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChungTuMuaHang chungTuMuaHang)
        {
            _chungTuMuaHangRepository.Add(chungTuMuaHang);
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
            _chungTuMuaHangRepository.Delete(id);
        }

        public IEnumerable<ChungTuMuaHang> GetAll()
        {
            return _chungTuMuaHangRepository.GetAll();
        }

        public ChungTuMuaHang GetByID(int id)
        {
            return _chungTuMuaHangRepository.GetSingleById(id);
        }

       

        public void Update(ChungTuMuaHang chungTuMuaHang)
        {
            _chungTuMuaHangRepository.Update(chungTuMuaHang);
        }

       
    }
}
