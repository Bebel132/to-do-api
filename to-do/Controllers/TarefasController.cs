using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using to_do.Models;
using to_do.Services;

namespace to_do.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private ITarefasService _tarefasService;

        public TarefasController(ITarefasService tarefasService)
        {
            _tarefasService = tarefasService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "GET - Tarefas" })]
        public async Task<ActionResult<IAsyncEnumerable<Tarefa>>> GetTarefas()
        {
            try
            {
                var tarefas = await _tarefasService.GetTarefas();
                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter tarefas");
            }
        }

        [HttpGet("{id:int}", Name = "GetTarefa")]
        [SwaggerOperation(Tags = new[] { "GET - Tarefa" })]
        public async Task<ActionResult<Tarefa>> GetTarefa(int id)
        {
            try
            {
                var tarefa = await _tarefasService.GetTarefa(id);
                if(tarefa == null)
                {
                    return NotFound();
                }
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter tarefa");
            }
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "POST - Tarefas" })]
        public async Task<ActionResult> CreateTarefa(Tarefa tarefa)
        {
            try
            {
                await _tarefasService.CreateTarefa(tarefa);
                return CreatedAtRoute(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar tarefa");
            }
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Tags = new[] { "PUT - Tarefas" })]
        public async Task<ActionResult> UpdateTarefa(int id, [FromBody] Tarefa tarefa)
        {
            try
            {
                if(tarefa.Id == id)
                {
                    await _tarefasService.UpdateTarefa(tarefa);
                    return Ok(tarefa);
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao editar tarefa");
            }
        }

        [HttpPut("AlterarEstadoTarefa/{id:int}")]
        [SwaggerOperation(Tags = new[] { "PUT - Alterar Status da Tarefas" })]
        public async Task<ActionResult> AlterarEstadoTarefa(int id)
        {
            try
            {
                var tarefa = await _tarefasService.GetTarefa(id);
                if (tarefa.Id == id)
                {
                    await _tarefasService.AlterarStatusTarefa(tarefa);
                    return Ok(tarefa);
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao mudar status da tarefa");
            }
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Tags = new[] { "DELETE - Tarefas" })]
        public async Task<ActionResult> DeleteTarefa(int id)
        {
            try
            {
                var tarefa = await _tarefasService.GetTarefa(id);
                if(tarefa == null)
                {
                    return NotFound();
                }
                else
                {
                    await _tarefasService.DeleteTarefa(tarefa);
                    return Ok();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao excluir tarefa");
            }
        }
    }
}
