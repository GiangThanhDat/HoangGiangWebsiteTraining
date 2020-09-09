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
    public interface IChiTietTraLaiHangMuaService
    {
        void Add(ChiTietTraLaiHangMua chiTietTraLaiHangMua);
        void Update(ChiTietTraLaiHangMua chiTietTraLaiHangMua);
        void delete(int id);
        IEnumerable<ChiTietTraLaiHangMua> GetAll();
        ChiTietTraLaiHangMua GetByID(int id);
        IQueryable<getchitiettralaihangmua> getchitiettralaihangmua(string MaTraLaiHang);
        void Commit();
        void Save();

    }
    public class ChiTietTraLaiHangMuaService : IChiTietTraLaiHangMuaService
    {
        IChiTietTraLaiHangMuaRepository _chiTietTraLaiHangMuaRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietTraLaiHangMuaService(IChiTietTraLaiHangMuaRepository chiTietTraLaiHangMuaRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietTraLaiHangMuaRepository = chiTietTraLaiHangMuaRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietTraLaiHangMua chiTietTraLaiHangMua)
        {
            _chiTietTraLaiHangMuaRepository.Add(chiTietTraLaiHangMua);
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
            _chiTietTraLaiHangMuaRepository.Delete(id);
        }

        public IEnumerable<ChiTietTraLaiHangMua> GetAll()
        {
            return _chiTietTraLaiHangMuaRepository.GetAll();
        }

        public ChiTietTraLaiHangMua GetByID(int id)
        {
            return _chiTietTraLaiHangMuaRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietTraLaiHangMua chiTietTraLaiHangMua)
        {
            _chiTietTraLaiHangMuaRepository.Update(chiTietTraLaiHangMua);
        }

        public IQueryable<getchitiettralaihangmua> getchitiettralaihangmua(string MaTraLaiHang)
        {
            return _chiTietTraLaiHangMuaRepository.getchitiettralaihangmua(MaTraLaiHang);
        }
    }
}
