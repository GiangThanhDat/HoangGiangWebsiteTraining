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
    public interface ILoaiChiService
    {
        void Add(LoaiChi loaiChi);
        void Update(LoaiChi loaiChi);
        void delete(int id);
        IEnumerable<LoaiChi> GetAll();
        LoaiChi GetByID(int id);
      
        void Commit();
        void Save();

    }
    public class LoaiChiService : ILoaiChiService
    {
        ILoaiChiRepository _loaiChiRepository;
        IUnitOfWork _unitOfWork;
        public LoaiChiService(ILoaiChiRepository loaiChiRepository, IUnitOfWork unitOfWork)
        {
            this._loaiChiRepository = loaiChiRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(LoaiChi loaiChi)
        {
            _loaiChiRepository.Add(loaiChi);
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
            _loaiChiRepository.Delete(id);
        }

        public IEnumerable<LoaiChi> GetAll()
        {
            return _loaiChiRepository.GetAll();
        }

        public LoaiChi GetByID(int id)
        {
            return _loaiChiRepository.GetSingleById(id);
        }

       

        public void Update(LoaiChi loaiChi)
        {
            _loaiChiRepository.Update(loaiChi);
        }

       
    }
}
