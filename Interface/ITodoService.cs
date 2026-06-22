using TodoApi.Contracts;
using TodoApi.Models;

namespace TodoApi.Interface
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo> GetByIdAsync(Guid id);
        Task<Todo> CreateTodoAsync(CreateTodoRequest request);
        Task<Todo> UpdateTodoAsync(Guid id, UpdateTodoRequest request);
        Task DeleteTodoAsync(Guid id);
    }
}