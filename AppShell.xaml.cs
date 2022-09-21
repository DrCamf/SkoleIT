using SkoleIT.Models;
using SkoleIT.ViewModels;
using SkoleIT.Views.Dashboard;
using System.Text.Json;

namespace SkoleIT;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        this.BindingContext = new AppShellViewModel();
    }
}
