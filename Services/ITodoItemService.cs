using AspNetCoreToDo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreToDo.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync();
    }
}
