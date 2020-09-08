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
    public interface IThongBaoService
    {
        void Add(ThongBao thongBao);
        void Update(ThongBao thongBao);
        void delete(int id);
        IEnumerable<ThongBao> GetAll();
        ThongBao GetByID(int id);
        IEnumerable<ThongBao> GetThongBao(string mssv);
        IQueryable<ThongBao> chitietTB(int MaSoTB);
        void Commit();
        void Save();


    }
    public class ThongBaoService : IThongBaoService
    {
        IThongBaoRepository _thongBaoRepository;
        IUnitOfWork _unitOfWork;
        public ThongBaoService(IThongBaoRepository thongBaoRepository, IUnitOfWork unitOfWork)
        {
            this._thongBaoRepository = thongBaoRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ThongBao thongBao)
        {
            _thongBaoRepository.Add(thongBao);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
        public void Commit()
        {
            _unitOfWork.Commit();
        }
		 public IQueryable<ThongBao> chitietTB(int MaSoTB)
        {
            return _thongBaoRepository.chitietTB(MaSoTB);
        }

        public void delete(int id)
        {
            _thongBaoRepository.Delete(id);
        }

        public IEnumerable<ThongBao> GetAll()
        {
            return _thongBaoRepository.GetAll();
        }

        public ThongBao GetByID(int id)
        {
            return _thongBaoRepository.GetSingleById(id);
        }

        public IEnumerable<ThongBao> GetThongBao(string mssv)
        {
            return _thongBaoRepository.GetThongBao(mssv);
        }

        public void Update(ThongBao thongBao)
        {
            _thongBaoRepository.Update(thongBao);
        }
    }
}
