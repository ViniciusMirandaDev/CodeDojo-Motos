using MotoDojo.Entities;
using MySqlConnector;

namespace MotoDojo.Repositories
{
    public class MotoAdoNetRepository : IMotoRepository
    {
        private readonly IConfiguration _configuration;

        public MotoAdoNetRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Moto GetById(int id)
        {
            using MySqlConnection connection = new(_configuration.GetConnectionString("Default"));

            connection.Open();

            var query = "SELECT Id, Modelo, Preco, Tipo, DataFabricacao, Marca, Placa  FROM moto WHERE Id = @id";

            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("id", id);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Moto
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Marca = reader["Marca"].ToString(),
                    DataFabricacao = DateTime.Parse(reader["DataFabricacao"].ToString()),
                    Modelo = reader["Modelo"].ToString(),
                    Placa = reader["Placa"].ToString(),
                    Preco = Convert.ToDecimal(reader["Preco"].ToString()),
                    Tipo = Convert.ToInt32(reader["Tipo"].ToString()),
                };
            }

            return null;
        }

        public List<Moto> GetAll()
        {
            var listaRetorno = new List<Moto>();

            using MySqlConnection connection = new(_configuration.GetConnectionString("Default"));

            connection.Open();

            var query = "SELECT Id, Modelo, Preco, Tipo, DataFabricacao, Marca, Placa  FROM moto";

            var command = new MySqlCommand(query, connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                listaRetorno.Add(new Moto
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Marca = reader["Marca"].ToString(),
                    DataFabricacao = DateTime.Parse(reader["DataFabricacao"].ToString()),
                    Modelo = reader["Modelo"].ToString(),
                    Placa = reader["Placa"].ToString(),
                    Preco = Convert.ToDecimal(reader["Preco"].ToString()),
                    Tipo = Convert.ToInt32(reader["Tipo"].ToString()),
                });
            }

            return listaRetorno;
        }


        public void Insert(Moto moto)
        {
            using MySqlConnection connection = new(_configuration.GetConnectionString("Default"));

            connection.Open();

            var query = @"INSERT INTO moto (Modelo, Preco, Tipo, DataFabricacao, Marca, Placa)
                                    VALUES(@modelo, @preco, @tipo, @dataFabricacao, @marca, @placa)";

            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("modelo", moto.Modelo);
            command.Parameters.AddWithValue("preco", moto.Preco);
            command.Parameters.AddWithValue("tipo", moto.Tipo);
            command.Parameters.AddWithValue("dataFabricacao", moto.DataFabricacao);
            command.Parameters.AddWithValue("marca", moto.Marca);
            command.Parameters.AddWithValue("placa", moto.Placa);

            command.ExecuteNonQuery();
        }

        public void Update(Moto moto)
        {
            using MySqlConnection connection = new(_configuration.GetConnectionString("Default"));

            connection.Open();

            var query = @"UPDATE moto SET Modelo = @modelo,
                                          Preco = @preco,
                                          Tipo = @tipo,
                                          DataFabricacao = @dataFabricacao,
                                          Marca = @marca,
                                          Placa = @placa
                          WHERE Id = @id";

            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("id", moto.Id);
            command.Parameters.AddWithValue("modelo", moto.Modelo);
            command.Parameters.AddWithValue("preco", moto.Preco);
            command.Parameters.AddWithValue("tipo", moto.Tipo);
            command.Parameters.AddWithValue("dataFabricacao", moto.DataFabricacao);
            command.Parameters.AddWithValue("marca", moto.Marca);
            command.Parameters.AddWithValue("placa", moto.Placa);

            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using MySqlConnection connection = new(_configuration.GetConnectionString("Default"));

            connection.Open();

            var query = "DELETE FROM moto WHERE Id = @id";

            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("id", id);
            
            command.ExecuteNonQuery();
        }
        
    }
}
