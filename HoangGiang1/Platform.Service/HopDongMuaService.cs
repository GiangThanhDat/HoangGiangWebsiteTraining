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
    public interface IHopDongMuaService
    {
        void Add(HopDongMua hopDongMua);
        void Update(HopDongMua hopDongMua);
        void delete(int id);
        IEnumerable<HopDongMua> GetAll();
        HopDongMua GetByID(int id);
        IQueryable<gethopdongmuahang> gethopdongmuahang(DateTime ngaydau, DateTime ngaycuoi);
        void Commit();
        void Save();

    }
    public class HopDongMuaService : IHopDongMuaService
    {
        IHopDongMuaRepository _hopDongMuaRepository;
        IUnitOfWork _unitOfWork;
        public HopDongMuaService(IHopDongMuaRepository hopDongMuaRepository, IUnitOfWork unitOfWork)
        {
            this._hopDongMuaRepository = hopDongMuaRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(HopDongMua hopDongMua)
        {
            _hopDongMuaRepository.Add(hopDongMua);
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
            _hopDongMuaRepository.Delete(id);
        }

        public IEnumerable<HopDongMua> GetAll()
        {
            return _hopDongMuaRepository.GetAll();
        }

        public HopDongMua GetByID(int id)
        {
            return _hopDongMuaRepository.GetSingleById(id);
        }

       

        public void Update(HopDongMua hopDongMua)
        {
            _hopDongMuaRepository.Update(hopDongMua);
        }

        public IQueryable<gethopdongmuahang> gethopdongmuahang(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _hopDongMuaRepository.gethopdongmuahang(ngaydau,ngaycuoi);
        }
    }
}
