using ContabilidadeBeatyBeach.DTOs.ComissoesDTO;
using ContabilidadeBeatyBeach.DTOs.HoraExtra;
using ContabilidadeBeatyBeach.DTOs.ResumoMensalDTO;

namespace ContabilidadeBeatyBeach.DTOs.User
{
    public class GetUsuarioOutputDTO
    {
        public int Id { get; set; }        
        public string Username { get; set; } 

        public decimal SalarioMensal { get; set; }

    }
}
