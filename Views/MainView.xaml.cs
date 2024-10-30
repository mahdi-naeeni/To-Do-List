namespace  MJMToDo.Views;
using MJMToDo.ViewModels;

public partial class MainView : ContentPage
{
	public MainView(MainViewModel viewModel)
	{
        InitializeComponent();
        viewModel.Navigation = Navigation;
        BindingContext = viewModel;
    }
}