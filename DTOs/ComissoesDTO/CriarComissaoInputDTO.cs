namespace ContabilidadeBeatyBeach.DTOs.ComissoesDTO
{
    public class CriarComissaoInputDTO
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int UserId { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
