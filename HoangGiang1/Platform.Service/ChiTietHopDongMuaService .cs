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
    public interface IChiTietHopDongMuaService
    {
        void Add(ChiTietHopDongMua chiTietHopDongMua);
        void Update(ChiTietHopDongMua chiTietHopDongMua);
        void delete(int id);
        IEnumerable<ChiTietHopDongMua> GetAll();
        ChiTietHopDongMua GetByID(int id);
        IQueryable<getchitiethopdongmua> getchitiethopdongmua(string MaHD);
        void Commit();
        void Save();

    }
    public class ChiTietHopDongMuaService : IChiTietHopDongMuaService
    {
        IChiTietHopDongMuaRepository _chiTietHopDongMuaRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietHopDongMuaService(IChiTietHopDongMuaRepository chiTietHopDongMuaRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietHopDongMuaRepository = chiTietHopDongMuaRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietHopDongMua chiTietHopDongMua)
        {
            _chiTietHopDongMuaRepository.Add(chiTietHopDongMua);
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
            _chiTietHopDongMuaRepository.Delete(id);
        }

        public IEnumerable<ChiTietHopDongMua> GetAll()
        {
            return _chiTietHopDongMuaRepository.GetAll();
        }

        public ChiTietHopDongMua GetByID(int id)
        {
            return _chiTietHopDongMuaRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietHopDongMua chiTietHopDongMua)
        {
            _chiTietHopDongMuaRepository.Update(chiTietHopDongMua);
        }

        public IQueryable<getchitiethopdongmua> getchitiethopdongmua(string MaHD)
        {
            return _chiTietHopDongMuaRepository.getchitiethopdongmua(MaHD);
        }
    }
}
