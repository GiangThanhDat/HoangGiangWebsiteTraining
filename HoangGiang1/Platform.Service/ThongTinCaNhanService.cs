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
    public interface IThongTinCaNhanService
    {
        void Add(ThongTinCaNhan thongTinCaNhan);
        void Update(ThongTinCaNhan thongTinCaNhan);
        void delete(int id);
        IEnumerable<ThongTinCaNhan> GetAll();
        ThongTinCaNhan GetByID(int id);
       
        void Save();
       ThongTinCaNhan GetLyLich(string msvc);
        void Commit();

    }
    public class ThongTinCaNhanService : IThongTinCaNhanService
    {
        IThongTinCaNhanRepository _thongTinCaNhanRepository;
        IUnitOfWork _unitOfWork;
        public ThongTinCaNhanService(IThongTinCaNhanRepository thongTinCaNhanRepository, IUnitOfWork unitOfWork)
        {
            this._thongTinCaNhanRepository = thongTinCaNhanRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ThongTinCaNhan thongTinCaNhan)
        {
            _thongTinCaNhanRepository.Add(thongTinCaNhan);
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
            _thongTinCaNhanRepository.Delete(id);
        }

        public IEnumerable<ThongTinCaNhan> GetAll()
        {
            return _thongTinCaNhanRepository.GetAll();
        }

        public ThongTinCaNhan GetByID(int id)
        {
            return _thongTinCaNhanRepository.GetSingleById(id);
        }

      
        public void Update(ThongTinCaNhan thongTinCaNhan)
        {
            _thongTinCaNhanRepository.Update(thongTinCaNhan);
        }

        public ThongTinCaNhan GetLyLich(string msvc)
        {
           return _thongTinCaNhanRepository.GetLyLich(msvc);
        }
    }
}
