﻿using ContabilidadeBeatyBeach.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadeBeatyBeach.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }   
        public DbSet<HoraExtra> HoraExtra { get; set; }
        public DbSet<ResumoMensal> ResumoMensal { get; set; }
        public DbSet<Comissoes> Comissoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasIndex(u => u.Username)
                    .IsUnique();

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
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.Comissoes)
                    .WithOne(c => c.Usuario)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
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
                    .HasColumnType("decimal(18,2)");

                entity.Property(r => r.TotalExtra)  
                    .HasColumnType("decimal(18,2)");

                entity.Property(r => r.TotalComissoes)                    
                    .HasColumnType("decimal(18,2)");

                entity.Property(r => r.SalarioTotal)
                    .IsRequired()
                    .HasColumnType("decimal(65,30)");
                
            });

            modelBuilder.Entity<Comissoes>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Data)
                .IsRequired();

                entity.Property(c => c.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

                entity.Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(255);
            });

        }
    }
}
