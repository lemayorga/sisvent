using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using apivent.Infrastructure.Seed;
using apivent.Infrastructure.Models;
using apivent.Infrastructure.Models.Security;

namespace apivent.Infrastructure.Context
{
    public class AppContexto : DbContext
    {
        public AppContexto() : base() { }
        public AppContexto(DbContextOptions options) : base(options) { }        
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedInitialize.Seed(modelBuilder);
            
        }
    }
}