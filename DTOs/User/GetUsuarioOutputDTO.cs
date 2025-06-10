using ContabilidadeBeatyBeach.DTOs.HoraExtra;

namespace ContabilidadeBeatyBeach.DTOs.User
{
    public class GetUsuarioOutputDTO
    {
        public int Id { get; set; }        
        public string Username { get; set; } 

        public decimal SalarioMensal { get; set; }
        public List<HoraExtraOutputDTO> HoraExtras { get; set; }
    }
}
