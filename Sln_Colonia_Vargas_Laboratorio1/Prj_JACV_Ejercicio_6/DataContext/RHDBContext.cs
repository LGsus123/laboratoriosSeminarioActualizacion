using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prj_JACV_Ejercicio_6.Models;

namespace Prj_JACV_Ejercicio_6.DataContext
{
    public class RHDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_JACV_Ejercicio_6;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Punto>()
                .HasKey(p => p.ID);

            modelBuilder.Entity<Punto>()
                .HasOne(p => p.Analista)
                .WithMany(a => a.Puntos)
                .HasForeignKey(p => p.ID_Analista);

            modelBuilder.Entity<Punto>()
                .HasOne(p => p.Talento)
                .WithMany(t => t.Puntos)
                .HasForeignKey(p => p.ID_Talento);

            modelBuilder.Entity<Analista>()
                .HasKey(a => a.ID_Analista);

            modelBuilder.Entity<AreaDesempeno>()
                .HasKey(ad => ad.ID_Area_Desempeno);

            modelBuilder.Entity<Talento>()
                .HasKey(t => t.ID_Talento);

            modelBuilder.Entity<Talento>()
                .HasOne(t => t.AreaDesempeno)
                .WithMany(ad => ad.Talentos)
                .HasForeignKey(t => t.ID_Area);
        }
        public DbSet<Analista> Analistas { get; set; }
        public DbSet<AreaDesempeno> AreasDesempeno { get; set; }
        public DbSet<Talento> Talentos { get; set; }
        public DbSet<Punto> Puntos { get; set; }

    }
}
