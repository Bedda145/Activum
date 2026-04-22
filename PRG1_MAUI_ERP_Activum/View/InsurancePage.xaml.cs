using PRG1_MAUI_ERP_Activum.ViewModels;

namespace PRG1_MAUI_ERP_Activum.View;

public partial class InsurancePage : ContentPage
{
	public InsurancePage()
	{
		InitializeComponent();
		BindingContext = new InsuranceViewModel();
	}
}