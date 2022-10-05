using Java.Lang;
using SkoleIT.ViewModels.Dashboard;
using System.Collections.ObjectModel;
using System.Globalization;
using static SkoleIT.ViewModels.Dashboard.NewSkemaViewModel;

namespace SkoleIT.Views.Dashboard;

public partial class NewSkema : ContentPage
{
    ObservableCollection<Week> weeks = new ObservableCollection<Week>();
    public ObservableCollection<Week> Weeks { get { return weeks; } }

    public NewSkema(NewSkemaViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
        DateTime today = DateTime.Now;

        int week = System.Globalization.ISOWeek.GetWeekOfYear(today);
        for (int i = -14; i < 14; i++)
        {
            weeks.Add(new Week() { WeekNumber = week + i });
        }

        //week_picker.SelectedIndex = 14;

        //GetWeekDays(today);
    }

    private void Mon_Clicked(object sender, EventArgs e)
    {
       Picker picker = sender as Picker;
        DateTime today = DateTime.Now;
      
       // App.Current.MainPage.DisplayAlert("Alert", number.ToString(), "Okay");
        var index = picker.SelectedIndex;
        var number = picker.Items[index];
        if (index != 0)
        {
            
            DateTime newdate = FirstDateOfWeekISO8601(2022, int.Parse(number));
            GetWeekDays(newdate);
            App.Current.MainPage.DisplayAlert("Alert", newdate.ToString(), "Okay");
        } else
        {
            App.Current.MainPage.DisplayAlert("Alert", "Index ikke sat", "Okay");
        }
    }

    public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
    {
        DateTime jan1 = new DateTime(year, 1, 1);
        int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

        // Use first Thursday in January to get first week of the year as
        // it will never be in Week 52/53
        DateTime firstThursday = jan1.AddDays(daysOffset);
        var cal = CultureInfo.CurrentCulture.Calendar;
        int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        var weekNum = weekOfYear;
        // As we're adding days to a date in Week 1,
        // we need to subtract 1 in order to get the right date for week #1
        if (firstWeek == 1)
        {
            weekNum -= 1;
        }

        // Using the first Thursday as starting week ensures that we are starting in the right year
        // then we add number of weeks multiplied with days
        var result = firstThursday.AddDays(weekNum * 7);

        // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
        return result.AddDays(-3);
    }



    private void GetWeekDays(DateTime today)
    {
        var monButton = (Button)this.FindByName("Mon");
        var tueButton = (Button)this.FindByName("Tue");
        var wedButton = (Button)this.FindByName("Wed");
        var thuButton = (Button)this.FindByName("Thu");
        var friButton = (Button)this.FindByName("Fri");

       // App.Current.MainPage.DisplayAlert("Alert", today.ToString(), "Okay");
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