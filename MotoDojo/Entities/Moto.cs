namespace MotoDojo.Entities
{
    public class Moto
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }
        public int Tipo { get; set; }
        public DateTime DataFabricacao { get; set; }  
        public string Marca { get; set; }
        public string Placa { get; set; }
    }
}
