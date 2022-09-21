using SkoleIT.ViewModels.Dashboard;

namespace SkoleIT.Views.Dashboard
{
    public partial class StudentProfilePage : ContentPage
    {
        public StudentProfilePage(StudentProfilePageViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
