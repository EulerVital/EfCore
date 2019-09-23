using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        /// <summary>
        /// Injetando Context configurado no ConfigureService da classe Startup
        /// </summary>
        /// <param name="applicationDbContext"></param>
        public CategoriaController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Salvar()
        {
            return View();
        }

        /// <summary>
        /// Retorna dados da categoria, utilizando o ToList() para fazer a consulta via Linq
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            var categorias = _applicationDbContext.Categorias.ToList();

            return View(categorias);
        }

        /// <summary>
        /// Metodo post comum salvando no banco de dados
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Salvar(Categoria categoria)
        {

            _applicationDbContext.Categorias.Add(categoria);
            _applicationDbContext.SaveChanges();

            return View();
        }

        /// <summary>
        /// Metodo post utilizando assincronização e salvando no banco de dados
        /// </summary>
        /// <remarks> 
        /// A vantagem da utilização do assíncrono, é que ele executa a ação do metodo salvar em outra Thread e a thread atual pode receber outras requisições.
        /// Se o banco estiver lento por exemplo, a aplicação deixará que outra thread cuide dessa operação assim o cliente não perceberá
        /// </remarks>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SalvarAsycn(Categoria modelo)
        {

            if(modelo.Id == 0)
                //nesse caso ele necessita, pois o objeto categoria não está na memoria, logo abaixo será add e será salvo com o metodo SaveChangesAsync
                _applicationDbContext.Categorias.Add(modelo);
            else
            {
                var categoria = _applicationDbContext.Categorias.First(c => c.Id == modelo.Id);
                categoria.Nome = modelo.Nome;
                categoria.IsPermiteEstoque = modelo.IsPermiteEstoque;

                //A linha de codigo abaixo não é necessario, no Entity Framework ao executar o metodo SaveChangesAsync, 
                //ele já entende que a variavel "categoria" que está na memoria será atualizada pois foi carregada no metodo acima

                //_applicationDbContext.Categorias.Update(categoria);
            }

            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int Id)
        {
            var categoria = _applicationDbContext.Categorias.First(c => c.Id == Id);

            return View("Salvar", categoria);
        }

        public async Task<IActionResult> Deletar(int id)
        {
            //carrega do entity framework
            var categoria = _applicationDbContext.Categorias.First(c => c.Id == id);
            //remove
            _applicationDbContext.Categorias.Remove(categoria);
            //e salva para atualizar o banco
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
             
    }
}