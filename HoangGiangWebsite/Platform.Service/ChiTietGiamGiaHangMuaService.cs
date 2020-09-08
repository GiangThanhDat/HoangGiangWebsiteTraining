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
    public interface IChiTietGiamGiaHangMuaService
    {
        void Add(ChiTietGiamGiaHangMua chiTietGiamGiaHangMua);
        void Update(ChiTietGiamGiaHangMua chiTietGiamGiaHangMua);
        void delete(int id);
        IEnumerable<ChiTietGiamGiaHangMua> GetAll();
        ChiTietGiamGiaHangMua GetByID(int id);
        IQueryable<getchitietgiamgiahnagmua> getchitietgiamgiahangmua(string MaGiamGiaHangMua);
        void Commit();
        void Save();

    }
    public class ChiTietGiamGiaHangMuaService : IChiTietGiamGiaHangMuaService
    {
        IChiTietGiamGiaHangMuaRepository _chiTietGiamGiaHangMuaRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietGiamGiaHangMuaService(IChiTietGiamGiaHangMuaRepository chiTietGiamGiaHangMuaRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietGiamGiaHangMuaRepository = chiTietGiamGiaHangMuaRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietGiamGiaHangMua chiTietGiamGiaHangMua)
        {
            _chiTietGiamGiaHangMuaRepository.Add(chiTietGiamGiaHangMua);
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
            _chiTietGiamGiaHangMuaRepository.Delete(id);
        }

        public IEnumerable<ChiTietGiamGiaHangMua> GetAll()
        {
            return _chiTietGiamGiaHangMuaRepository.GetAll();
        }

        public ChiTietGiamGiaHangMua GetByID(int id)
        {
            return _chiTietGiamGiaHangMuaRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietGiamGiaHangMua chiTietGiamGiaHangMua)
        {
            _chiTietGiamGiaHangMuaRepository.Update(chiTietGiamGiaHangMua);
        }

        public IQueryable<getchitietgiamgiahnagmua> getchitietgiamgiahangmua(string MaGiamGiaHangMua)
        {
            return _chiTietGiamGiaHangMuaRepository.getchitietgiamgiahangmua(MaGiamGiaHangMua);
        }
    }
}
