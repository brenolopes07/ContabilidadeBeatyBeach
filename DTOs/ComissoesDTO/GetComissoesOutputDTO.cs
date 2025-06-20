namespace ContabilidadeBeatyBeach.DTOs.ComissoesDTO
{
    public class GetComissoesOutputDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }

        
    }
    }
