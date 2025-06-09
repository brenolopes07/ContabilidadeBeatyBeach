namespace ContabilidadeBeatyBeach.Domain.DTOs.CalculoSalario
{
    public class CalculoSalarioDTO
    {
        public string Usuario { get; set; } = default!;
        public string Mes { get; set; } = default!;
        public decimal SalarioBase { get; set; }
        public decimal ValorHora { get; set; }
        public decimal TotalHorasExtras { get; set; }
        public decimal ValorHorasExtras { get; set; }
        public decimal SalarioTotal { get; set; }
        public List<HoraExtraDetalhadaDTO> HorasExtras { get; set; } = new();
    }
    public class HoraExtraDetalhadaDTO
    {
        public string Data { get; set; }
        public decimal QuantidadeHoras { get; set; }
        public string Tipo { get; set; } = default!;
        public decimal ValorHoraExtra { get; set; }
        public decimal ValorCaculado { get; set; }
    }

}
