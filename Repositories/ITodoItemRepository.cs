using MJMToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJMToDo.Repositories
{
    internal interface ITodoItemRepository
    {
        event EventHandler<TodoItem> OnItemAdded;
        event EventHandler<TodoItem> OnItemUpdated;
        Task<List<TodoItem>> GetItemsAsync();
        Task AddItemAsync(TodoItem item);
        Task UpdateItemAsync(TodoItem item);
        Task AddOrUpdateAsync(TodoItem item);
    }
}
