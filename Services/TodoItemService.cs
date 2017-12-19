using AspNetCoreToDo.Data;
using AspNetCoreToDo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreToDo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(NewTodoItem newItem, ApplicationUser currentUser)
        {
            var entity = new TodoItem
            {
                Id = Guid.NewGuid(),
                IsDone = false,
                Title = newItem.Title,
                DueAt = newItem.DueAt,
                OwnerId = currentUser.Id
            };


            _context.Items.Add(entity);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;

        }

        public async Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync(ApplicationUser currentUser)
        {
            return await _context.Items
                .Where(x => x.IsDone == false && x.OwnerId == currentUser.Id)
               .ToArrayAsync();
        }

        public async Task<bool> MarkDoneAsync(Guid id, ApplicationUser currentUser)
        {
            var item = await _context.Items
                .Where(x => x.Id == id && x.OwnerId == currentUser.Id)
                .SingleOrDefaultAsync();

            if (item == null) return false;

            item.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }


    }
}
