using ContabilidadeBeatyBeach.Domain.Entity.Enum;

namespace ContabilidadeBeatyBeach.Domain.DTOs
{
    public class CriarHoraExtraDTO
    {
        public DateTime Data { get; set; }
        public decimal QuantidadeHoras { get; set; }
        public TipoDeExtra Tipo { get; set; }
        public int UserId { get; set; } 
    }
}
