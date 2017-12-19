﻿using AspNetCoreToDo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreToDo.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<bool> AddItemAsync(NewTodoItem newItem)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync()
        {
            IEnumerable<TodoItem> items = new[]
            {
                 new TodoItem
                 {
                      Title="Learn ASP.NET Core",
                      DueAt=DateTimeOffset.Now.AddDays(1)
                 },
                 new TodoItem
                 {
                     Title="Build awesome apps",
                     DueAt=DateTimeOffset.Now.AddDays(2)
                 }

          };

            return Task.FromResult(items);
        }

        public Task<bool> MarkDoneAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
