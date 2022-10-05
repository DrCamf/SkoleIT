
using Kotlin;
using Microsoft.Maui;
using SkoleIT.Models;
using SkoleIT.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkoleIT.ViewModels.Dashboard
{
    public class NewSkemaViewModel : BaseViewModel
    {
        private List<Skema> skemaCollection = new List<Skema>();
        private readonly StudentSkemaService _studentSkemaService;
        //private string week;
        // public string Week { get { return week; } }
      
        ObservableCollection<Skema> skemas = new ObservableCollection<Skema>();
        public ObservableCollection<Skema> Skemas { get { return skemas; } }

        /* public List<Skema> SkemaCollection
         {
             get { return skemaCollection; }
             set { skemaCollection = value; }
         }*/
        public event PropertyChangedEventHandler PropertyChanged;


        public DateTime MonButton { get; set; }
        public DateTime TueButton { get; set; }
        public DateTime WedButton { get; set; }
        public DateTime ThurButton { get; set; }
        public DateTime FriButton { get; set; }
       

        public class Week
        {
            public int WeekNumber { get; set; }
        }

        public int SelectedWeek { get { return newWeek.WeekNumber; }  
            set
            {
                if (newWeek.WeekNumber != value)
                {
                    newWeek.WeekNumber = value;
                    // OnPropertyChanged(nameof(SelectedWeekIndex));
                    SelectedWeekIndex = newWeek.WeekNumber;

                }
            }
        }
      
        public Week newWeek;


        
        public int _selectedWeekIndex;
        public int SelectedWeekIndex
        {
            get { return _selectedWeekIndex ; }
            set
            {
                if(_selectedWeekIndex != value)
                {
                    _selectedWeekIndex = value;
                     OnPropertyChanged(nameof(SelectedWeekIndex));
                    SelectedWeekIndex =_selectedWeekIndex;
                   
                }
            }
        }

        ObservableCollection<Week> weeks = new ObservableCollection<Week>();
        public ObservableCollection<Week> Weeks { get { return weeks; } }

        public NewSkemaViewModel(StudentSkemaService studentSkemaService)
        {
            _studentSkemaService = studentSkemaService;
            ChangeDay = new Command<DateTime>(StartList);
            NewWeekCom = new Command(WeekList);
            DateTime today = DateTime.Today;

            GetWeekDays(today);

            StartList(today);

            int week = System.Globalization.ISOWeek.GetWeekOfYear(today);
            for (int i = -14; i < 14; i++)
            {
                weeks.Add(new Week() { WeekNumber = week + i });
            }
        }

        public Command<DateTime> ChangeDay { get; set; }
        public Command NewWeekCom { get; set; }
        private void DataToListView(int week)
        {
            App.Current.MainPage.DisplayAlert("Alert", _selectedWeekIndex.ToString(), "Okay");
        }
        public void WeekList()
        {

        }

        private void StartList(DateTime today)
        {
            skemas.Clear();
     
            //App.Current.MainPage.DisplayAlert("Alert", week, "Okay");
            int userid = App.UserDetails.UserId;

            var response = _studentSkemaService.GetSkemaByDate(today, userid);
            foreach (Skema skema in response.ToArray())
            {
                if (skema != null)
                {
                    skema.Start = skema.ClassBegin.ToString("H:mm");
                    skema.End = skema.ClassEnd.ToString("H:mm");
                }
                skemas.Add(skema);
            }
        }


        private void GetWeekDays(DateTime today)
        {
            

            // App.Current.MainPage.DisplayAlert("Alert", today.ToString(), "Okay");
            switch (today.ToString("dddd"))
            {
                case "Monday":
                    MonButton = today;
                    TueButton = today.AddDays(1);
                    WedButton = today.AddDays(2);
                    ThurButton = today.AddDays(3);
                    FriButton = today.AddDays(4);
                    break;
                case "Tuesday":
                    MonButton = today.AddDays(-1);
                    TueButton = today;
                    WedButton = today.AddDays(1);
                    ThurButton = today.AddDays(2);
                    FriButton = today.AddDays(3);
                    break;
                case "Wednesday":
                    MonButton = today.AddDays(-2);
                    TueButton = today.AddDays(-1);
                    WedButton = today;
                    ThurButton = today.AddDays(1);
                    FriButton = today.AddDays(2);
                    break;
                case "Thursday":
                    MonButton = today.AddDays(-3);
                    TueButton = today.AddDays(-2);
                    WedButton = today.AddDays(-1);
                    ThurButton = today;
                    FriButton = today.AddDays(1);
                    break;
                case "Friday":
                    MonButton = today.AddDays(-4);
                    TueButton = today.AddDays(-3);
                    WedButton = today.AddDays(-2);
                    ThurButton = today.AddDays(-1);
                    FriButton = today;
                    break;



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

        void SetNewWeek()
        {
            App.Current.MainPage.DisplayAlert("Alert", _selectedWeekIndex.ToString(), "Okay");
            var weeeek = _selectedWeekIndex;
        }

        protected new virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
