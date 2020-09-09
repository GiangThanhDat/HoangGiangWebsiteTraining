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
    public interface IChiTietPhieuChiService
    {
        void Add(ChiTietPhieuChi chiTietPhieuChi);
        void Update(ChiTietPhieuChi chiTietPhieuChi);
        void delete(int id);
        IEnumerable<ChiTietPhieuChi> GetAll();
        ChiTietPhieuChi GetByID(int id);
        IEnumerable<ChiTietPhieuChi> xemChiTietPhieuChi(string MaPC);

        void Commit();
        void Save();

    }
    public class ChiTietPhieuChiService : IChiTietPhieuChiService
    {
        IChiTietPhieuChiRepository _chiTietPhieuChiRepository;
        IUnitOfWork _unitOfWork;
        public ChiTietPhieuChiService(IChiTietPhieuChiRepository chiTietPhieuChiRepository, IUnitOfWork unitOfWork)
        {
            this._chiTietPhieuChiRepository = chiTietPhieuChiRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChiTietPhieuChi chiTietPhieuChi)
        {
            _chiTietPhieuChiRepository.Add(chiTietPhieuChi);
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
            _chiTietPhieuChiRepository.Delete(id);
        }

        public IEnumerable<ChiTietPhieuChi> GetAll()
        {
            return _chiTietPhieuChiRepository.GetAll();
        }

        public ChiTietPhieuChi GetByID(int id)
        {
            return _chiTietPhieuChiRepository.GetSingleById(id);
        }

       

        public void Update(ChiTietPhieuChi chiTietPhieuChi)
        {
            _chiTietPhieuChiRepository.Update(chiTietPhieuChi);
        }
        public IEnumerable<ChiTietPhieuChi> xemChiTietPhieuChi(string MaPC)
        {
            return _chiTietPhieuChiRepository.GetMulti(x => x.MaPhieuChi == MaPC);
        }

    }
}
