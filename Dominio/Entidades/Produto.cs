using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        /// <summary>
        /// Categoria, com o virtual que serve para o EntityFramework saiba que essa propriedade pode ser carregada de forma lenta
        /// </summary>
        public virtual Categoria Categoria { get; set; }

        public int CategoriaId { get; set; }

        public bool Ativo { get; set; }
    }
}
