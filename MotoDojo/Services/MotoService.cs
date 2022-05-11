using MotoDojo.Entities;
using MotoDojo.Repositories;


namespace MotoDojo.Services
{
    public class MotoService : IMotoService
    {

        private IMotoRepository _repository;

        public MotoService(IMotoRepository repository)
        {
            _repository = repository;
        }

        public List<Moto> GetAll()
        {
            return _repository.GetAll();
        }

        public Moto GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(Moto moto)
        {
            _repository.Insert(moto);
        }

        public void Update(Moto moto)
        {
            _repository.Update(moto);
            
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
  
    }
}
