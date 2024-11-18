using MJMToDo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MJMToDo.Views;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MJMToDo.Models;

namespace MJMToDo.ViewModels
{
    public partial class MainViewModel : ViewModel
    {

        private readonly ITodoItemRepository repository;
        private readonly IServiceProvider services;
        [ObservableProperty]
        ObservableCollection<TodoItemViewModel> items;
        [ObservableProperty]
        TodoItemViewModel selectedItem;

        public MainViewModel(ITodoItemRepository repository, IServiceProvider services)
        {
            repository.OnItemAdded += (sender, item) =>
            items.Add(CreateTodoItemViewModel(item));
            repository.OnItemUpdated += (sender, item) =>
            Task.Run(async () => await LoadDataAsync());
            this.repository = repository;
            this.services = services;
            Task.Run(async () => await LoadDataAsync());

        }
        private async Task LoadDataAsync()
        {
            var items = await repository.GetItemsAsync();
            if (!showAll)
            {
                items = items.Where(x => x.Completed == false).ToList();
            }
            var itemViewModels = items.Select(i => CreateTodoItemViewModel(i));
            Items = new ObservableCollection<TodoItemViewModel>
        (itemViewModels);
        }
        [RelayCommand]
        public async Task AddItemAsync() => await Navigation.PushAsync(services.GetRequiredService<ItemView>());
        private TodoItemViewModel CreateTodoItemViewModel(TodoItem item)
        {
            var itemViewModel = new TodoItemViewModel(item);
            itemViewModel.ItemStatusChanged += ItemStatusChanged;
            return itemViewModel;
        }
        private void ItemStatusChanged(object sender, EventArgs e)
        {
            if (sender is TodoItemViewModel item)
            {
                if (!showAll && item.Item.Completed)
                {
                    Items.Remove(item);
                }
                Task.Run(async () => await repository.UpdateItemAsync(item.Item));
            }
        }
        [ObservableProperty]
        bool showAll;



        partial void OnSelectedItemChanging(TodoItemViewModel value)
        {
            if (value == null)
            {
                return;
            }
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await NavigateToItemAsync(value);
            });
        }
        private async Task NavigateToItemAsync(TodoItemViewModel item)
        {
            var itemView = services.GetRequiredService<ItemView>();
            var vm = itemView.BindingContext as ItemViewModel;
            vm.Item = item.Item;
            itemView.Title = "Edit todo item";
            await Navigation.PushAsync(itemView);




        }
        [RelayCommand]
        private async Task ToggleFilterAsync()
        {
            showAll = !showAll;
            await LoadDataAsync();
        }
    }
}