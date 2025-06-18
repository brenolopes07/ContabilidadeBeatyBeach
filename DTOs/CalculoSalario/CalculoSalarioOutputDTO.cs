namespace ContabilidadeBeatyBeach.DTOs.CalculoSalario
{
    public class CalculoSalarioOutputDTO
    {
        public string Usuario { get; set; } = default!;
        public string Mes { get; set; } = default!;
        public decimal SalarioBase { get; set; }
        public decimal ValorHora { get; set; }
        public decimal TotalHorasExtras { get; set; }
        public decimal ValorHorasExtras { get; set; }
        public decimal TotalComissoes { get; set; }
        public decimal SalarioTotal { get; set; }
        
    }
    
}
