using AspNetCoreToDo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreToDo.Services
{
    public interface ITodoItemService
    {
        Task<bool> MarkDoneAsync(Guid id, ApplicationUser currentUser);
        Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync(ApplicationUser currentUser);
        Task<bool> AddItemAsync(NewTodoItem newItem, ApplicationUser currentUser);
    }
}
