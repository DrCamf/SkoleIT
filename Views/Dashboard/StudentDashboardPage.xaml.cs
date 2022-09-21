using SkoleIT.ViewModels.Dashboard;
namespace SkoleIT.Views.Dashboard;

public partial class StudentDashboardPage : ContentPage
{
	public StudentDashboardPage(StudentDashboardPage viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}