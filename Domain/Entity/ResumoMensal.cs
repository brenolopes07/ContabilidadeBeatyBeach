namespace ContabilidadeBeatyBeach.Domain.Entity
{
    public class ResumoMensal
    {
        public int Id { get; set;  }
        public string Mes { get; set; }
        public decimal TotalHoras { get; set; }
        public decimal TotalExtra { get; set; }

        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; }
    }
}
