namespace ContabilidadeBeatyBeach.DTOs.ComissoesDTO
{
    public class CriarComissaoOutputDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int UserId { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public UserSimplificadoComissoesDto User { get; set; }
    }

    public class UserSimplificadoComissoesDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public decimal SalarioMensal { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
