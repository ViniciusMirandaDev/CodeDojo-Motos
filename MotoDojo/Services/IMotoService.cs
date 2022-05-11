using MotoDojo.Entities;

namespace MotoDojo.Services
{
    public interface IMotoService
    {
        List<Moto> GetAll();
        Moto GetById(int id);
        void Insert(Moto moto);
        void Update(Moto moto);
        void Delete(int id);
    }
}
