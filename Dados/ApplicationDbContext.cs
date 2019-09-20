using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dados
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// O construtor é preciso receber as opções que seria, qual o banco, a connectionString entre outras configurações de banco
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Abaixo os DbSet's são usados para mapear as entidades do banco de dados

        /// <summary>
        /// Classe categoria, sendo mapeada no banco de dados
        /// </summary>
        public DbSet<Categoria> Categorias { get; set; }
    }
}
