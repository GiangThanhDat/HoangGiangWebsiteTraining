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
    public interface IGiamGiaHangMuaService
    {
        void Add(GiamGiaHangMua giamGiaHangMua);
        void Update(GiamGiaHangMua giamGiaHangMua);
        void delete(int id);
        IEnumerable<GiamGiaHangMua> GetAll();
        GiamGiaHangMua GetByID(int id);
        IQueryable<getgiamgiahangmua> getgiamgiahangmua(DateTime ngaydau, DateTime ngaycuoi);
        void Commit();
        void Save();

    }
    public class GiamGiaHangMuaService : IGiamGiaHangMuaService
    {
        IGiamGiaHangMuaRepository _giamGiaHangMuaRepository;
        IUnitOfWork _unitOfWork;
        public GiamGiaHangMuaService(IGiamGiaHangMuaRepository giamGiaHangMuaRepository, IUnitOfWork unitOfWork)
        {
            this._giamGiaHangMuaRepository = giamGiaHangMuaRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(GiamGiaHangMua giamGiaHangMua)
        {
            _giamGiaHangMuaRepository.Add(giamGiaHangMua);
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
            _giamGiaHangMuaRepository.Delete(id);
        }

        public IEnumerable<GiamGiaHangMua> GetAll()
        {
            return _giamGiaHangMuaRepository.GetAll();
        }

        public GiamGiaHangMua GetByID(int id)
        {
            return _giamGiaHangMuaRepository.GetSingleById(id);
        }

       

        public void Update(GiamGiaHangMua giamGiaHangMua)
        {
            _giamGiaHangMuaRepository.Update(giamGiaHangMua);
        }

        public IQueryable<getgiamgiahangmua> getgiamgiahangmua(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _giamGiaHangMuaRepository.getgiamgiahangmua(ngaydau, ngaycuoi);
        }
    }
}
