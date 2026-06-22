using Microsoft.AspNetCore.Mvc;
using TodoApi.Contracts;
using TodoApi.Interface;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoServices;
        public TodoController(ITodoService todoServices)
        {
            _todoServices = todoServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var todos = await _todoServices.GetAllAsync();
                return Ok(new { data = todos });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving all todos", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoAsync(CreateTodoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newTodo = await _todoServices.CreateTodoAsync(request);
                return StatusCode(201, new { data = newTodo, message = "Todo item successfully created" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the  crating Todo Item", error = ex.Message });

            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var todo = await _todoServices.GetByIdAsync(id);
                if (todo == null)
                {
                    return NotFound(new { message = $"No Todo item with Id {id} found." });
                }
                return Ok(new { data = todo });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while retrieving the Todo item with Id {id}.", error = ex.Message });
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTodoAsync(Guid id, UpdateTodoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var todo = await _todoServices.GetByIdAsync(id);
                if (todo == null)
                {
                    return NotFound(new { message = $"Todo Item  with id {id} not found" });
                }

                var updatedTodo = await _todoServices.UpdateTodoAsync(id, request);
                return Ok(new { data = updatedTodo });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while updating blog post with id {id}", error = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTodoAsync(Guid id)
        {
            // return StatusCode(500, new { message = $"An error occurred while deleting Todo Item  with id {id}" });
            try
            {
                await _todoServices.DeleteTodoAsync(id);
                return Ok(new { message = $"Todo  with id {id} successfully deleted" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while deleting Todo Item  with id {id}", error = ex.Message });
            }
        }
    }
}