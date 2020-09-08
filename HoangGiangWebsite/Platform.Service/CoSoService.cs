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
    public interface ICoSoService
    {
        void Add(CoSo coSo);
        void Update(CoSo coSo);
        void delete(int id);
        IEnumerable<CoSo> GetAll();
        CoSo GetByID(String id);
        getCoSo getTenCoSo(string msnv);
        void Commit();
        void Save();
        IEnumerable<CoSo> GetByKeyWord(string keyword);
    }
    public class CoSoService : ICoSoService
    {
        ICoSoRepository _coSoRepository;
        IUnitOfWork _unitOfWork;
        public CoSoService(ICoSoRepository coSoRepository, IUnitOfWork unitOfWork)
        {
            this._coSoRepository = coSoRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(CoSo coSo)
        {
            _coSoRepository.Add(coSo);
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
            _coSoRepository.Delete(id);
        }

        public IEnumerable<CoSo> GetAll()
        {
            return _coSoRepository.GetAll();
        }

   
        public void Update(CoSo coSo)
        {
            _coSoRepository.Update(coSo);
        }

        public getCoSo getTenCoSo(string msnv)
        {
            return _coSoRepository.getTenCoSo(msnv);
        }

        public CoSo GetByID(string id)
        {
            return _coSoRepository.GetSingleById(id);
        }


        //return _khachHangRepository.GetMulti(x=>x.TenKhachHang.Contains(keyword)||x.DiaChi.Contains(keyword)||x.MaKhachHang.Contains(keyword));
        IEnumerable<CoSo> ICoSoService.GetByKeyWord(string keyword)
        {
            return _coSoRepository.GetMulti(x => x.MaCoSo.Contains(keyword) 
            || x.TenCoSo.Contains(keyword) 
            || x.DiaChi.Contains(keyword) 
            || x.CapToChuc.Contains(keyword));
        }

        
    }

}
