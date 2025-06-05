using ContabilidadeBeatyBeach.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadeBeatyBeach.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Usuarios { get; set; }   
        public DbSet<HoraExtra> HoraExtra { get; set; }
        public DbSet<ResumoMensal> ResumoMensal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(u => u.SalarioMensal)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(u => u.DataCadastro)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasMany(u => u.HoraExtras)
                    .WithOne(h => h.User)
                    .HasForeignKey(h => h.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(u => u.ResumoMensal)
                    .WithOne(r => r.Usuario)
                    .HasForeignKey(r => r.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<HoraExtra>(entity =>
            {
                entity.HasKey(h => h.Id);

                entity.Property(h => h.Data)
                    .IsRequired();
                    

                entity.Property(h => h.QuantidadeHoras)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(h => h.Tipo)
                    .IsRequired()
                    .HasConversion<int>();
            });

            modelBuilder.Entity<ResumoMensal>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Mes)
                    .IsRequired()
                    .HasMaxLength(7); 

                entity.Property(r => r.TotalHoras)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(r => r.TotalExtra)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
            });

        }
    }
}
