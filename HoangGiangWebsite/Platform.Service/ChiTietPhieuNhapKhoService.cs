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
    public interface IChiTietPhieuNhapKhoService
    {
        void Add(ChiTietPhieuNhapKho chiTietPhieuNhapKho);
        void Update(ChiTietPhieuNhapKho chiTietPhieuNhapKho);
        void delete(int id);
        IEnumerable<ChiTietPhieuNhapKho> GetAll();
        ChiTietPhieuNhapKho GetByID(int id);
        IQueryable<chitietxuatnhapkho> getchitietxuatnhapkho(string MaPhieuNhapKho);
        void Commit();
        void Save();

    }
    public class ChiTietPhieuNhapKhoService : IChiTietPhieuNhapKhoService
    {
        IChiTietPhieuNhapKhoRepository _chiTietPhieuNhapKhoRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietPhieuNhapKhoService(IChiTietPhieuNhapKhoRepository chiTietPhieuNhapKhoRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietPhieuNhapKhoRepository = chiTietPhieuNhapKhoRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietPhieuNhapKho chiTietPhieuNhapKho)
        {
            _chiTietPhieuNhapKhoRepository.Add(chiTietPhieuNhapKho);
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
            _chiTietPhieuNhapKhoRepository.Delete(id);
        }

        public IEnumerable<ChiTietPhieuNhapKho> GetAll()
        {
            return _chiTietPhieuNhapKhoRepository.GetAll();
        }

        public ChiTietPhieuNhapKho GetByID(int id)
        {
            return _chiTietPhieuNhapKhoRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietPhieuNhapKho chiTietPhieuNhapKho)
        {
            _chiTietPhieuNhapKhoRepository.Update(chiTietPhieuNhapKho);
        }

        public IQueryable<chitietxuatnhapkho> getchitietxuatnhapkho(string MaPhieuNhapKho)
        {
            return _chiTietPhieuNhapKhoRepository.getchitietxuatnhapkho(MaPhieuNhapKho);
        }
    }
}
