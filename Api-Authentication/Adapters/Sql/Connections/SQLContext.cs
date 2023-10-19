using Api_Authentication.Adapters.Sql.ModelsSql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Reflection.Emit;


namespace Api_Authentication.Adapters.Sql.Connections
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options)
        { 
        }

        public DbSet<Usuario>? Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Usuario>().ToTable("tbl_usuarios");
            mb.Entity<Usuario>().HasKey(c => c.matricula);
            mb.Entity<Usuario>().Property(c => c.nome).IsRequired();
            mb.Entity<Usuario>().Property(c => c.sobrenome).IsRequired();
            mb.Entity<Usuario>().Property(c => c.senha).IsRequired();
            mb.Entity<Usuario>().Property(c => c.datacriacao).IsRequired();

        }
     }
}
