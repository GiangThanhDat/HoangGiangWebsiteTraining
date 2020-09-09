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
    public interface IThongTinTuyenDungService
    {
        void Add(ThongTinTuyenDung thongTinTuyenDung);
        void Update(ThongTinTuyenDung thongTinTuyenDung);
        void delete(int id);
        IEnumerable<ThongTinTuyenDung> GetAll();
        ThongTinTuyenDung GetByID(int id);
        IEnumerable<ThongTinTuyenDung> thongTinTuyenDung(string msnv);
        ThongTinTuyenDung getID(int ID);
        void Commit();
        void Save();


    }
    public class ThongTinTuyenDungService : IThongTinTuyenDungService
    {
        IThongTinTuyenDungRepository _thongTinTuyenDungRepository;
        IUnitOfWork _unitOfWork;
        public ThongTinTuyenDungService(IThongTinTuyenDungRepository thongTinTuyenDungRepository, IUnitOfWork unitOfWork)
        {
            this._thongTinTuyenDungRepository = thongTinTuyenDungRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ThongTinTuyenDung thongTinTuyenDung)
        {
            _thongTinTuyenDungRepository.Add(thongTinTuyenDung);
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
            _thongTinTuyenDungRepository.Delete(id);
        }

        public IEnumerable<ThongTinTuyenDung> GetAll()
        {
            return _thongTinTuyenDungRepository.GetAll();
        }

        public ThongTinTuyenDung GetByID(int id)
        {
            return _thongTinTuyenDungRepository.GetSingleById(id);
        }

       

        public void Update(ThongTinTuyenDung thongTinTuyenDung)
        {
            _thongTinTuyenDungRepository.Update(thongTinTuyenDung);
        }

        public IEnumerable<ThongTinTuyenDung> thongTinTuyenDung(string msnv)
        {
            return _thongTinTuyenDungRepository.thongTinTuyenDung(msnv);
        }

        public ThongTinTuyenDung getID(int ID)
        {
            return _thongTinTuyenDungRepository.getID(ID);
        }
    }
}
