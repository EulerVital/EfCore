using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        /// Método sobrescrito para habilitar o LazyLoading 
        /// </summary>
        /// <remarks>
        /// Lazy loading é um padrão de projeto de software, comumente utilizado em linguagens de programação, 
        /// para adiar a inicialização de um objeto até o ponto em que ele é necessário. 
        /// Isso pode contribuir para a eficiência no funcionamento de um programa, se utilizado adequadamente pois pode causar efeito contrario. 
        /// </remarks>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        //Abaixo os DbSet's são usados para mapear as entidades do banco de dados

        /// <summary>
        /// Classe categoria, sendo mapeada no banco de dados
        /// </summary>
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
