using System.ComponentModel.DataAnnotations;

namespace ContabilidadeBeatyBeach.Domain.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(128)]
        public string Username { get; set; }
        public decimal SalarioMensal { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public List<HoraExtra> HoraExtras { get; set; }
        public List<ResumoMensal> ResumoMensal { get; set; }
    }
}
