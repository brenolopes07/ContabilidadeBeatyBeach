namespace ContabilidadeBeatyBeach.DTOs.ResumoMensalDTO
{
    public class GetResumoMensalDTO
    {
        public int Id { get; set; }
        public string mesAno { get; set; }

        public decimal? TotalHoras { get; set; }
        public decimal? TotalExtra { get; set; }
        public decimal? TotalComissoes { get; set; }
        public decimal SalarioTotal { get; set; }

    }
}
