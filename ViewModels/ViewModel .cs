using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
namespace MJMToDo.ViewModels
{


    [ObservableObject]
    public abstract partial class ViewModel
    {
        public INavigation Navigation { get; set; }
    }
}


