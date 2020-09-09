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
    public interface IChungTuBanHangService
    {
        void Add(ChungTuBanHang chungTuBanHang);
        void Update(ChungTuBanHang chungTuBanHang);
        void delete(int id);
        IEnumerable<ChungTuBanHang> GetAll();
        ChungTuBanHang GetByID(int id);
        ChungTuBanHang GetByID(string id);
        IQueryable<getchungtubanhang> getchungtubanhang(DateTime ngaydau, DateTime ngaycuoi);
        IQueryable<getchungtubanhang> gettheongay(DateTime ngaydau, DateTime ngaycuoi, bool dathaydoi);
        IEnumerable<getchungtubanhang> getctbh(DateTime ngaydau, DateTime ngaycuoi, string macoso, bool dathaydoi);
        IQueryable<getchungtubanhang> getthongkechungtubanhangtimeline(string mactbh);

        IEnumerable<lichsutongquan> getlichsu();



        void Commit();
        void Save();

    }
    public class ChungTuBanHangService : IChungTuBanHangService
    {
        IChungTuBanHangRepository _chungTuBanHangRepository;
        IUnitOfWork _unitOfWork;
        public ChungTuBanHangService(IChungTuBanHangRepository chungTuBanHangRepository, IUnitOfWork unitOfWork)
        {
            this._chungTuBanHangRepository = chungTuBanHangRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ChungTuBanHang chungTuBanHang)
        {
            _chungTuBanHangRepository.Add(chungTuBanHang);
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
            _chungTuBanHangRepository.Delete(id);
        }

        public IEnumerable<ChungTuBanHang> GetAll()
        {
            return _chungTuBanHangRepository.GetAll();
        }

        public ChungTuBanHang GetByID(int id)
        {
            return _chungTuBanHangRepository.GetSingleById(id);
        }

       

        public void Update(ChungTuBanHang chungTuBanHang)
        {
            _chungTuBanHangRepository.Update(chungTuBanHang);
        }

        public IQueryable<getchungtubanhang> getchungtubanhang(DateTime ngaydau, DateTime ngaycuoi)
        {
            return _chungTuBanHangRepository.getchungtubanhang(ngaydau, ngaycuoi);
        }

        public ChungTuBanHang GetByID(string id)
        {
            return _chungTuBanHangRepository.GetSingleByCondition(x => x.MaChungTuBanHang == id);
        }

        public IQueryable<getchungtubanhang> gettheongay(DateTime ngaydau, DateTime ngaycuoi, bool dathaydoi)
        {
            return _chungTuBanHangRepository.gettheongay(ngaydau, ngaycuoi, dathaydoi);
        }

        public IEnumerable<getchungtubanhang> getctbh(DateTime ngaydau, DateTime ngaycuoi, string macoso, bool dathaydoi)
        {
            return _chungTuBanHangRepository.getctbh(ngaydau, ngaycuoi, macoso, dathaydoi);
        }

        public IEnumerable<lichsutongquan> getlichsu()
        {
            return _chungTuBanHangRepository.getlichsu();
        }

        public IQueryable<getchungtubanhang> getthongkechungtubanhangtimeline(string mactbh)
        {
            return _chungTuBanHangRepository.getthongkechungtubanhangtimeline(mactbh);
        }
    }
}
