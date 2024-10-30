using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MJMToDo.Repositories;

namespace MJMToDo.ViewModels
{
    public class ItemViewModel : ViewModel
    {
        private readonly ITodoItemRepository repository;
        public ItemViewModel(ITodoItemRepository repository)
        {
            this.repository = repository;
        }
    }
}
