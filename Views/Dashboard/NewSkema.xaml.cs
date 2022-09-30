using SkoleIT.ViewModels.Dashboard;
using System.Collections.ObjectModel;

namespace SkoleIT.Views.Dashboard;

public partial class NewSkema : ContentPage
{
   

    public NewSkema(NewSkemaViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
        DateTime today = DateTime.Now;
        GetWeekDays(today);

    }

    private void Mon_Clicked(object sender, EventArgs e)
    {
       
    }





    private void GetWeekDays(DateTime today)
    {
        var monButton = (Button)this.FindByName("Mon");
        var tueButton = (Button)this.FindByName("Tue");
        var wedButton = (Button)this.FindByName("Wed");
        var thuButton = (Button)this.FindByName("Thu");
        var friButton = (Button)this.FindByName("Fri");


        switch (today.ToString("dddd"))
        {
            case "Monday":
                monButton.CommandParameter = today;
                tueButton.CommandParameter = today.AddDays(1);
                wedButton.CommandParameter = today.AddDays(2);
                thuButton.CommandParameter = today.AddDays(3);
                friButton.CommandParameter = today.AddDays(4);
                break;
            case "Tuesday":
                monButton.CommandParameter = today.AddDays(-1);
                tueButton.CommandParameter = today;
                wedButton.CommandParameter = today.AddDays(1);
                thuButton.CommandParameter = today.AddDays(2);
                friButton.CommandParameter = today.AddDays(3);
                break;
            case "Wednesday":
                monButton.CommandParameter = today.AddDays(-2);
                tueButton.CommandParameter = today.AddDays(-1);
                wedButton.CommandParameter = today;
                thuButton.CommandParameter = today.AddDays(1);
                friButton.CommandParameter = today.AddDays(2);
                break;
            case "Thursday":
                monButton.CommandParameter = today.AddDays(-3);
                tueButton.CommandParameter = today.AddDays(-2);
                wedButton.CommandParameter = today.AddDays(-1);
                thuButton.CommandParameter = today;
                friButton.CommandParameter = today.AddDays(1);
                break;
            case "Friday":
                monButton.CommandParameter = today.AddDays(-4);
                tueButton.CommandParameter = today.AddDays(-3);
                wedButton.CommandParameter = today.AddDays(-2);
                thuButton.CommandParameter = today.AddDays(-1);
                friButton.CommandParameter = today;
                break;



        }
    }
}