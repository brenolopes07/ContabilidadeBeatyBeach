using ContabilidadeBeatyBeach.Domain.Entity.Enum;

namespace ContabilidadeBeatyBeach.DTOs.HoraExtra
{
    public class CriarHoraExtraInputDTO
    {
        public DateTime Data { get; set; }
        public decimal QuantidadeHoras { get; set; }
        public TipoDeExtra Tipo { get; set; }
        public int UserId { get; set; } 
    }
}
