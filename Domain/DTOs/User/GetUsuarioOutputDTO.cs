using ContabilidadeBeatyBeach.Domain.DTOs.HoraExtra;

namespace ContabilidadeBeatyBeach.Domain.DTOs.User
{
    public class GetUsuarioOutputDTO
    {
        public int Id { get; set; }        
        public string Username { get; set; } 

        public decimal SalarioMensal { get; set; }
        public List<HoraExtraOutputDTO> HoraExtras { get; set; }
    }
}
