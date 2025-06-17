namespace ContabilidadeBeatyBeach.Domain.Entity
{
    public class ResumoMensal
    {
        public int Id { get; set;  }
        public string Mes { get; set; }
        public decimal? TotalHoras { get; set; }
        public decimal? TotalExtra { get; set; }
        public decimal? TotalComissoes { get; set; }
        public decimal SalarioTotal { get; set; }

        public int UserId { get; set; }
        public Usuarios Usuario { get; set; }
    }
}
