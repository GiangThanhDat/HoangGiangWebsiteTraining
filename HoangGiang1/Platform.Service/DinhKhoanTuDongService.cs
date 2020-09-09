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
    public interface IDinhKhoanTuDongService
    {
        void Add(DinhKhoanTuDong dinhKhoanTuDong);
        void Update(DinhKhoanTuDong dinhKhoanTuDong);
        void delete(int id);
        IEnumerable<DinhKhoanTuDong> GetAll();
        DinhKhoanTuDong getID(string id);


        DinhKhoanTuDong GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class DinhKhoanTuDongService : IDinhKhoanTuDongService
    {
        IDinhKhoanTuDongRepository _dinhKhoanTuDongRepository;
        IUnitOfWork _unitOfWork;
        public DinhKhoanTuDongService(IDinhKhoanTuDongRepository DinhKhoanTuDongRepository, IUnitOfWork unitOfWork)
        {
            this._dinhKhoanTuDongRepository = DinhKhoanTuDongRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(DinhKhoanTuDong dinhKhoanTuDong)
        {
            _dinhKhoanTuDongRepository.Add(dinhKhoanTuDong);
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
            _dinhKhoanTuDongRepository.Delete(id);
        }

        public IEnumerable<DinhKhoanTuDong> GetAll()
        {
            return _dinhKhoanTuDongRepository.GetAll();
        }

        public DinhKhoanTuDong GetByID(int id)
        {
            return _dinhKhoanTuDongRepository.GetSingleById(id);
        }

       

        public void Update(DinhKhoanTuDong dinhKhoanTuDong)
        {
            _dinhKhoanTuDongRepository.Update(dinhKhoanTuDong);
        }

        public DinhKhoanTuDong getID(string id)
        {
            return _dinhKhoanTuDongRepository.GetSingleById(id);
        }
    }
}
