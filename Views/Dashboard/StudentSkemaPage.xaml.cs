using SkoleIT.ViewModels.Dashboard;

namespace SkoleIT.Views.Dashboard
{
    public partial class StudentSkemaPage : ContentPage
    {
        public StudentSkemaPage(StudentSkemaPageViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
