using ContabilidadeBeatyBeach.Data;
using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadeBeatyBeach.Repository
{
    public class UserRepository : IUserRepository 
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuarios> ObterPorIdAsync(int id)
        {
            return await _context.Usuarios
            .Include(u => u.HoraExtras)
            .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuarios> ObterPorUsernameAsync(string username)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<List<Usuarios>> ObterTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuarios> AdicionarAsync(Usuarios user)
        {
            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Usuarios> AtualizarAsync(Usuarios user)
        {
            _context.Usuarios.Update(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<bool> DeletarAsync(int id)
        {
            var user = await ObterPorIdAsync(id);
            if (user == null) return false;
            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
