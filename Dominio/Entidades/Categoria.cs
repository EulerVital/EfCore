using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool IsPermiteEstoque { get; set; }
    }
}
