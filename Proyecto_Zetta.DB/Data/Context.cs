﻿using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.DB.Data
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Instalador> Instaladores { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<Comentario> comentarios { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Forma_de_Pago> Formas_De_Pago { get; set; }

        
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                          .SelectMany(t => t.GetForeignKeys())
                                          .Where(fk => !fk.IsOwnership
                                          && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Seguimiento>()
                        .HasMany(s => s.Comentarios)
                        .WithOne(c => c.Seguimiento)
                        .HasForeignKey(c => c.SeguimientoId);
        }
    }
}
