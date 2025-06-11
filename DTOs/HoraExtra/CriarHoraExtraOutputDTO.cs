using ContabilidadeBeatyBeach.Domain.Entity.Enum;

namespace ContabilidadeBeatyBeach.DTOs.HoraExtra
{
    public class CriarHoraExtraOutputDTO
    {       
            public int Id { get; set; }
            public DateTime Data { get; set; }
            public decimal QuantidadeHoras { get; set; }
            public TipoDeExtra Tipo { get; set; }
            public int UserId { get; set; }
            public UserSimplificadoDto User { get; set; }

        
        }

        public class UserSimplificadoDto
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public decimal SalarioMensal { get; set; }
            public DateTime DataCadastro { get; set; }

       
        }
    }

