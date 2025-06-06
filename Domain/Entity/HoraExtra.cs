using ContabilidadeBeatyBeach.Domain.Entity.Enum;

namespace ContabilidadeBeatyBeach.Domain.Entity
{
    public class HoraExtra
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal QuantidadeHoras { get; set; }
        public TipoDeExtra Tipo { get; set; }

        public int UserId { get; set; }
        public Usuarios User { get; set; }
    }
}
