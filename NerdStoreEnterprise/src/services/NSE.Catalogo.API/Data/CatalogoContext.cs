using Microsoft.EntityFrameworkCore;
using NSE.Catalogo.API.Models;
using NSE.Core.Data;
using NSE.Core.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options)
            :base(options){}

        public DbSet<Produto> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // o EF irá ignorar estas duas classes, evitando erros no momento de persistir as demais entidades que façam referência
            // a elas
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            // irá aplicar as configurações com base em todas as classes que herdem IEntityTypeConfiguration
            // que estejam configurando uma entidade definida neste contexto
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }
        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }

    }
}
