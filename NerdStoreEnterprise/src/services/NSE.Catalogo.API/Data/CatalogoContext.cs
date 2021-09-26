﻿using Microsoft.EntityFrameworkCore;
using NSE.Catalogo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Data
{
    public class CatalogoContext : DbContext
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options)
            :base(options){}

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // irá aplicar as configurações com base em todas as classes que herdem IEntityTypeConfiguration
            // que estejam configurando uma entidade definida neste contexto
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }
    }
}