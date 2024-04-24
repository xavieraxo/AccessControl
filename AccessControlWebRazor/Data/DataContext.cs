using AccessControlWebRazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessControlWebRazor.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<LecturasGaritaLog> LecturasGaritaLog { get; set; }
        public DbSet<LecturaPatente> LecturasPatentes { get; set; }
        public DbSet<Procesamiento> Procesamiento { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<CentroCosto> CentroCosto { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<TipoPersona> TipoPersonas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PersonalExterno> PersonalExternos { get; set; }
        public DbSet<Maquinaria> Maquinarias { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<ProcesamientoPersonalExterno> ProcesamientoPersonalExternos { get; set; }
        public DbSet<ProcesamientoVehiculoExterno> ProcesamientoVehiculoExternos { get; set; }
        public DbSet<ProcesamientoVehiculos> ProcesamientoVehiculoProdengs { get; set; }
        
        //public DbSet<ProcesamientoPersonal> ProcesamientoPersonal { get; set; }
        public DbSet<Invitado> Invitados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Procesamiento>()
            .HasOne(p => p.CentroCostoModel)
            .WithMany()
            .HasForeignKey(p => p.CentroCosto);

            modelBuilder.Entity<ProcesamientoVehiculos>()
           .HasOne(p => p.CentroCostoModel)
           .WithMany()
           .HasForeignKey(p => p.CentroCostoId);
        }

    }

}
