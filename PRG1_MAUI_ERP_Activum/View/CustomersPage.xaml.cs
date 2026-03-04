using PRG1_MAUI_ERP_Activum.ViewModels;

namespace PRG1_MAUI_ERP_Activum.View;

public partial class CustomersPage : ContentPage
{
	public CustomersPage()
	{
		InitializeComponent();

		BindingContext = new CustomerViewModel();
	}
}