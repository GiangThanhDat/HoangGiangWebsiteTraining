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
    public interface ITaiSanService
    {
        void Add(TaiSan taiSan);
        void Update(TaiSan taiSan);
        void delete(int id);
        IEnumerable<TaiSan> GetAll();
        TaiSan GetByID(int id);
        IQueryable<Chucnangthongketaisan> getThongkeTaiSan();
        IQueryable<Chucnangthongketaisan> ChucNangLocTaiSanTheoMaCoSo(string MaCoSo);
        IQueryable<Chucnangthongketaisan> ChucNangLocTaiSanTheoKieuTaiSan(string KieuTaiSan);
        IQueryable<getnguoinhap> getnguoinhap(string msnv);

        IQueryable<Chucnangthongketaisan> getThongkeNguoiQuanLyTS();
        void Commit();
        void Save();


    }
    public class TaiSanService : ITaiSanService
    {
        ITaiSanRepository _taiSanRepository;
        IUnitOfWork _unitOfWork;
        public TaiSanService(ITaiSanRepository taiSanRepository, IUnitOfWork unitOfWork)
        {
            this._taiSanRepository = taiSanRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(TaiSan taiSan)
        {
            _taiSanRepository.Add(taiSan);
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
            _taiSanRepository.Delete(id);
        }

        public IEnumerable<TaiSan> GetAll()
        {
            return _taiSanRepository.GetAll();
        }

        public TaiSan GetByID(int id)
        {
            return _taiSanRepository.GetSingleById(id);
        }

     
        public void Update(TaiSan taiSan)
        {
            _taiSanRepository.Update(taiSan);
        }

        public IQueryable<Chucnangthongketaisan> getThongkeTaiSan()
        {
            return _taiSanRepository.getThongkeTaiSan();
        }

        public IQueryable<Chucnangthongketaisan> ChucNangLocTaiSanTheoMaCoSo(string MaCoSo)
        {
            return _taiSanRepository.ChucNangLocTaiSanTheoMaCoSo(MaCoSo);
        }

        public IQueryable<Chucnangthongketaisan> ChucNangLocTaiSanTheoKieuTaiSan(string KieuTaiSan)
        {
            return _taiSanRepository.ChucNangLocTaiSanTheoKieuTaiSan(KieuTaiSan);
        }

        public IQueryable<getnguoinhap> getnguoinhap(string msnv)
        {
            return _taiSanRepository.getnguoinhap(msnv);
        }

        public IQueryable<Chucnangthongketaisan> getThongkeNguoiQuanLyTS()
        {
            return _taiSanRepository.getThongkeNguoiQuanLyTS();
        }
    }
}
