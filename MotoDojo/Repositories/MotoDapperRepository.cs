using MotoDojo.Entities;
using Dapper;
using MySqlConnector;

namespace MotoDojo.Repositories
{
    public class MotoDapperRepository : IMotoRepository
    {
        private readonly IConfiguration _configuration;

        public MotoDapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Moto GetById(int id)
        {
            using MySqlConnection connection = new(_configuration.GetConnectionString("Default"));

            var query = "SELECT Id, Modelo, Preco, Tipo, DataFabricacao, Marca, Placa  FROM moto WHERE Id = @id";

            return connection.QueryFirstOrDefault<Moto>(query, new { id = id });
        }

        public List<Moto> GetAll()
        {
            using MySqlConnection connection = new(_configuration.GetConnectionString("Default"));

            var query = "SELECT Id, Modelo, Preco, Tipo, DataFabricacao, Marca, Placa  FROM moto";

            return connection.Query<Moto>(query).ToList();
        }

        public void Insert(Moto moto)
        {
            using MySqlConnection connection = new(_configuration.GetConnectionString("Default"));

            var query = @"INSERT INTO moto (Modelo, Preco, Tipo, DataFabricacao, Marca, Placa)
                                    VALUES(@modelo, @preco, @tipo, @dataFabricacao, @marca, @placa)";

            connection.Execute(query, new
            {
                modelo = moto.Modelo, 
                preco = moto.Preco,
                tipo = moto.Tipo,
                dataFabricacao = moto.DataFabricacao,
                marca = moto.Marca,
                placa = moto.Placa,
            });
        }

        public void Update(Moto moto)
        {
            using MySqlConnection connection = new(_configuration.GetConnectionString("Default"));

            var query = @"UPDATE moto SET Modelo = @modelo,
                                          Preco = @preco,
                                          Tipo = @tipo,
                                          DataFabricacao = @dataFabricacao,
                                          Marca = @marca,
                                          Placa = @placa
                          WHERE Id = @id";

            connection.Execute(query, new
            {
                id = moto.Id,
                modelo = moto.Modelo,
                preco = moto.Preco,
                tipo = moto.Tipo,
                dataFabricacao = moto.DataFabricacao,
                marca = moto.Marca,
                placa = moto.Placa,
            });
        }

        public void Delete(int id)
        {
            using MySqlConnection connection = new(_configuration.GetConnectionString("Default"));

            var query = "DELETE FROM moto WHERE Id = @id";

            connection.Execute(query, new { id = id });
        }
    }
}
