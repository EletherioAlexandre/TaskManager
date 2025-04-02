using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Tasks.Delete;
using TaskManager.Application.UseCases.Tasks.GetAll;
using TaskManager.Application.UseCases.Tasks.GetById;
using TaskManager.Application.UseCases.Tasks.Register;
using TaskManager.Application.UseCases.Tasks.Update;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagerController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllTasksJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            ResponseAllTasksJson response = new GetAllTasksUseCase().Execute();

            if (response.Tasks.Any())
            {
                return Ok(response);
            }

            return NoContent();

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromRoute] int id)
        {
            ResponseTaskJson response = new GetTaskByIdUseCase().Execute(id);

            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterTask), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] RequestTasksJson request)
        {
            ResponseRegisterTask response = new RegisterTaskUseCase().Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] RequestTasksJson request, int id)
        {
            new UpdateTaskUseCase().Execute(request, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            new DeleteTaskUseCase().Execute(id);

            return NoContent();
        }
    }
}
