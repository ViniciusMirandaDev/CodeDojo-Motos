using MotoDojo.Entities;

namespace MotoDojo.Repositories
{
    public interface IMotoRepository
    {
        List<Moto> GetAll();
        Moto GetById(int id);
        void Insert(Moto moto);
        void Update(Moto moto);
        void Delete(int id);
    }
}
