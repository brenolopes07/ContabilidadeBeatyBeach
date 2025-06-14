namespace ContabilidadeBeatyBeach.Domain.Entity
{
    public class Comissoes
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
       
        public virtual Usuarios Usuarios { get; set; } 
    }
}
