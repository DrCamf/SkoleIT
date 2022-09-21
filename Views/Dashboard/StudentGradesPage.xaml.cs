using SkoleIT.ViewModels.Dashboard;

namespace SkoleIT.Views.Dashboard
{
    public partial class StudentGradesPage : ContentPage
    {
        public StudentGradesPage(StudentGradesPageViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
