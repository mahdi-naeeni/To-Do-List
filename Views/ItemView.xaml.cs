using MJMToDo.ViewModels;
namespace MJMToDo.Views;

public partial class ItemView : ContentPage
{
	public ItemView(ItemViewModel viewmodel)
	{
        InitializeComponent();
        viewmodel.Navigation = Navigation;
        BindingContext = viewmodel;
    }
}
