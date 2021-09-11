using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet("")]
        public IActionResult Lista()
        {
            IList<SerieModel> series = new List<SerieModel>();

            series.Add(new SerieModel() { Titulo = "Título Série" });
            series.Add(new SerieModel() { Titulo = "Título Série" });
            series.Add(new SerieModel() { Titulo = "Título Série" });
            series.Add(new SerieModel() { Titulo = "Título Série" });
            series.Add(new SerieModel() { Titulo = "Título Série" });
            series.Add(new SerieModel() { Titulo = "Título Série" });

            return Ok(series);
        }
        [HttpPut("id")]
        public IActionResult Atualizar(int id, [FromBody] SerieModel model)
        {
            return Ok(model);
        }
        [HttpDelete("id")]
        public IActionResult Excluir(int id)
        {
            return Ok(id);
        }
        [HttpPost("id")]
        public IActionResult Insere([FromBody] SerieModel model)
        {
            return Ok(model);
        }
        [HttpGet("id")]
        public IActionResult Consulta(int id)
        {
            return Ok(id);
        }
    }
}
