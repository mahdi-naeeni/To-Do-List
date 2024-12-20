﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MJMToDo.Models;
using CommunityToolkit.Mvvm.Input;
namespace MJMToDo.ViewModels
{

    public partial class TodoItemViewModel : ViewModel
{
         public TodoItemViewModel(TodoItem item) => Item = item;
         public event EventHandler ItemStatusChanged;
         [ObservableProperty]
         TodoItem item;
         public string StatusText => Item.Completed ? "Reactivate" : "Completed";
        [RelayCommand]
        void ToggleCompleted()
        {
            Item.Completed = !Item.Completed;
            ItemStatusChanged?.Invoke(this, new EventArgs());
        }
    }   
}