using MJMToDo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MJMToDo.Views;
using CommunityToolkit.Mvvm.Input;

namespace MJMToDo.ViewModels
{
    public partial class MainViewModel : ViewModel
    {
        private readonly ITodoItemRepository repository;
        private readonly IServiceProvider services;

        public MainViewModel(ITodoItemRepository repository, IServiceProvider services)
        {
            this.repository = repository;
            this.services = services;
            Task.Run(async () => await LoadDataAsync());

        }
        private async Task LoadDataAsync()
        {
        }
        [RelayCommand]
        public async Task AddItemAsync() => await Navigation.PushAsync(services.GetRequiredService<ItemView>());
    }
}
