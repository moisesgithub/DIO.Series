using DIO.Series.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DIO.Series.Web.Controllers
{
    [Route("[controller]")]
    public class SerieController : Controller
    {
        /*
         GET = Retorna algo
         POST = Inserir algo
         PUT = Alterar algo
         DELETE = Excluir algo
         */

        private readonly IRepositorio<Serie> _repositorioSerie;

        public SerieController(IRepositorio<Serie> repositorioSerie)
        {
            _repositorioSerie = repositorioSerie;
        }

        [HttpGet("")]
        public IActionResult Lista()
        {
            return Ok(_repositorioSerie.Lista().Select(s => new SerieModel(s)));            
        }

        [HttpPut("id")]
        public IActionResult Atualizar(int id, [FromBody] SerieModel model)
        {
            _repositorioSerie.Atualiza(id, model.ToSerie()); // Pesquisar AutoMapper
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult Excluir(int id)
        {
            _repositorioSerie.Exclui(id);
            return NoContent();
        }

        [HttpPost("")]
        public IActionResult Insere([FromBody] SerieModel model)
        {
            model.Id = _repositorioSerie.ProximoId();

            Serie serie = model.ToSerie();
           
            _repositorioSerie.Insere(model.ToSerie());
            return Created(" ", serie);
        }

        [HttpGet("id")]
        public IActionResult Consulta(int id)
        {
            return Ok(new SerieModel(_repositorioSerie.Lista().FirstOrDefault(s => s.Id == id)));
        }
    }
}
