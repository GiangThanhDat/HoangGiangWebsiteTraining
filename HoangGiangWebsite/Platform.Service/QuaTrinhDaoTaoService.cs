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
    public interface IQuaTrinhDaoTaoService
    {
        void Add(QuaTrinhDaoTao quaTrinhDaoTao);
        void Update(QuaTrinhDaoTao quaTrinhDaoTao);
        void delete(int id);
        QuaTrinhDaoTao DELETE(int ID);

       
        IEnumerable<QuaTrinhDaoTao> GetAll();
        IEnumerable<QuaTrinhDaoTao> GetQuaTrinhDaoTao(string msnv);
        QuaTrinhDaoTao GetByID(int id);
        void Save();
        QuaTrinhDaoTao getID(int ID);
        void Commit();

    }
    public class QuaTrinhDaoTaoService : IQuaTrinhDaoTaoService
    {
        IQuaTrinhDaoTaoRepository _quaTrinhDaoTaoRepository;
        IUnitOfWork _unitOfWork;
        public QuaTrinhDaoTaoService(IQuaTrinhDaoTaoRepository quaTrinhDaoTaoRepository, IUnitOfWork unitOfWork)
        {
            this._quaTrinhDaoTaoRepository = quaTrinhDaoTaoRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(QuaTrinhDaoTao quaTrinhDaoTao)
        {
            _quaTrinhDaoTaoRepository.Add(quaTrinhDaoTao);
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
            _quaTrinhDaoTaoRepository.Delete(id);
        }

        public IEnumerable<QuaTrinhDaoTao> GetAll()
        {
            return _quaTrinhDaoTaoRepository.GetAll();
        }

        public QuaTrinhDaoTao GetByID(int id)
        {
            return _quaTrinhDaoTaoRepository.GetSingleById(id);
        }

        public void Update(QuaTrinhDaoTao quaTrinhDaoTao)
        {
            _quaTrinhDaoTaoRepository.Update(quaTrinhDaoTao);
        }

        public IEnumerable<QuaTrinhDaoTao> GetQuaTrinhDaoTao(string msnv)
        {
            return _quaTrinhDaoTaoRepository.GetQuaTrinhDaoTao(msnv);
        }

        public QuaTrinhDaoTao getID(int ID)
        {
            return _quaTrinhDaoTaoRepository.getID(ID);
        }

        public QuaTrinhDaoTao DELETE(int ID)
        {
            return _quaTrinhDaoTaoRepository.Delete(ID);
        }
    }
}
