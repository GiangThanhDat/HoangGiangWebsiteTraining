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
    public interface IHoanThanhCongViecService
    {
        void Add(HoanThanhCongViec hoanThanhCongViec);
        void Update(HoanThanhCongViec hoanThanhCongViec);
        void delete(int id);
        IEnumerable<HoanThanhCongViec> GetAll();
        HoanThanhCongViec GetByID(int id);
        IEnumerable<HoanThanhCongViec> GetHoanThanhCongViec(string msnv);
        void Commit();
        void Save();
        HoanThanhCongViec getID(int id);


    }
    public class HoanThanhCongViecService : IHoanThanhCongViecService
    {
        IHoanThanhCongViecRepository _hoanThanhCongViecService;
        IUnitOfWork _unitOfWork;
        public HoanThanhCongViecService(IHoanThanhCongViecRepository hoanThanhCongViecRepository, IUnitOfWork unitOfWork)
        {
            this._hoanThanhCongViecService = hoanThanhCongViecRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(HoanThanhCongViec hoanThanhCongViec)
        {
            _hoanThanhCongViecService.Add(hoanThanhCongViec);
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
            _hoanThanhCongViecService.Delete(id);
        }

        public IEnumerable<HoanThanhCongViec> GetAll()
        {
            return _hoanThanhCongViecService.GetAll();
        }

        public HoanThanhCongViec GetByID(int id)
        {
            return _hoanThanhCongViecService.GetSingleById(id);
        }

       

        public void Update(HoanThanhCongViec hoanThanhCongViec)
        {
            _hoanThanhCongViecService.Update(hoanThanhCongViec);
        }

        public IEnumerable<HoanThanhCongViec> GetHoanThanhCongViec(string msnv)
        {
            return _hoanThanhCongViecService.GetHoanThanhCongViec(msnv);
        }

        public HoanThanhCongViec getID(int id)
        {
            return _hoanThanhCongViecService.getID(id);
        }
    }
}
