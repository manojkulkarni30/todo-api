using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApi.AppDataContext;
using TodoApi.Contracts;
using TodoApi.Interface;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _context;
        private readonly ILogger<TodoService> _logger;
        private readonly IMapper _mapper;

        public TodoService(TodoDbContext context, ILogger<TodoService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Todo> CreateTodoAsync(CreateTodoRequest request)
        {
            try
            {
                await Task.Delay(3000);
                var todo = _mapper.Map<Todo>(request);
                todo.DateCreated = DateTime.Now;
                _context.Todos.Add(todo);
                await _context.SaveChangesAsync();
                return todo;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Todo item.");
                throw new Exception("An error occurred while creating the Todo item.");
            }
        }

        public async Task DeleteTodoAsync(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No  item found with the id {id}");
            }
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            var todos = await _context.Todos.OrderByDescending(c => c.DateCreated).ToListAsync();

            await Task.Delay(3000);

            return todos == null ? new List<Todo>() : todos;
        }

        public async Task<Todo> GetByIdAsync(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                throw new KeyNotFoundException($"No Todo item with Id {id} found.");
            }
            return todo;
        }

        public async Task<Todo> UpdateTodoAsync(Guid id, UpdateTodoRequest request)
        {

            try
            {
                var todo = await _context.Todos.FindAsync(id);
                if (todo == null)
                {
                    throw new Exception($"Todo item with id {id} not found.");
                }

                if (request.Title != null)
                {
                    todo.Title = request.Title;
                }

                if (request.Description != null)
                {
                    todo.Description = request.Description;
                }

                if (request.IsCompleted != null)
                {
                    todo.IsCompleted = request.IsCompleted.Value;
                }

                if (request.DueDate != null)
                {
                    todo.DueDate = request.DueDate.Value;
                }

                if (request.ReminderDate != null)
                {
                    todo.ReminderDate = request.ReminderDate.Value;
                }

                todo.Priority = request.Priority;
                todo.Category = request.Category;
                todo.DateUpdated = DateTime.Now;

                await _context.SaveChangesAsync();

                await Task.Delay(3000);

                return todo;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the todo item with id {id}.");
                throw;
            }
        }
    }
}