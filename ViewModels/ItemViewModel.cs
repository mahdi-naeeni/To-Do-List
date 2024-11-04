using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MJMToDo.Models;
using MJMToDo.Repositories;

namespace MJMToDo.ViewModels
{
    public partial class ItemViewModel : ViewModel
    {
        private readonly ITodoItemRepository repository;

        public TodoItem Item { get; }

        [ObservableProperty]
        TodoItem item;
        public ItemViewModel(ITodoItemRepository repository)
        {
            this.repository = repository;
            Item = new TodoItem() { Due = DateTime.Now.AddDays(1) };
        }
        [RelayCommand]
        public async Task SaveAsync()
        {
            await repository.AddOrUpdateAsync(Item);
            await Navigation.PopAsync();
        }
    }
}
