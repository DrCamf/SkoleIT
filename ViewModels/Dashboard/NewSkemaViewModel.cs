using SkoleIT.Models;
using SkoleIT.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
       
        public class Fruit
        {
            public string FruitName { get; set; }
            public string FruitStuff { get; set; }
        }

       // ObservableCollection<Fruit> fruits = new ObservableCollection<Fruit>();
       // public ObservableCollection<Fruit> Fruits { get { return fruits; } }
        ObservableCollection<Skema> skemas = new ObservableCollection<Skema>();
        public ObservableCollection<Skema> Skemas { get { return skemas; } }

        /* public List<Skema> SkemaCollection
         {
             get { return skemaCollection; }
             set { skemaCollection = value; }
         }*/
        public class Week
        {
            public int WeekNumber { get; set; }
        }

        ObservableCollection<Week> weeks = new ObservableCollection<Week>();
        public ObservableCollection<Week> Weeks { get { return weeks; } }


        public NewSkemaViewModel(StudentSkemaService studentSkemaService)
        {
            _studentSkemaService = studentSkemaService;
            ChangeDay = new Command<DateTime>(StartList);
            WeekSelect = new Command<int>(DataToListView);



            /*fruits.Add(new Fruit() { FruitName = "Apple", FruitStuff= "You know" });
            fruits.Add(new Fruit() { FruitName = "Orange", FruitStuff = "You know more" });
            fruits.Add(new Fruit() { FruitName = "Banana", FruitStuff = "You know less" });
            fruits.Add(new Fruit() { FruitName = "Grape", FruitStuff = "You don't know" });
            fruits.Add(new Fruit() { FruitName = "Mango", FruitStuff = "You know what" });*/



            DateTime today = DateTime.Today;
            StartList(today);

            
            int week = System.Globalization.ISOWeek.GetWeekOfYear(today);
            weeks.Add(new Week() { WeekNumber = week - 7 });
            weeks.Add(new Week() { WeekNumber = week - 6 });
            weeks.Add(new Week() { WeekNumber = week - 5 });
            weeks.Add(new Week() { WeekNumber = week - 4 });
            weeks.Add(new Week() { WeekNumber = week - 3 });
            weeks.Add(new Week() { WeekNumber = week - 2 });
            weeks.Add(new Week() { WeekNumber = week - 1 });
            weeks.Add(new Week() { WeekNumber = week });
            weeks.Add(new Week() { WeekNumber = week +1 });
            weeks.Add(new Week() { WeekNumber = week + 2 });
            weeks.Add(new Week() { WeekNumber = week + 3 });
            weeks.Add(new Week() { WeekNumber = week + 4 });
            weeks.Add(new Week() { WeekNumber = week + 5 });
            weeks.Add(new Week() { WeekNumber = week + 6 });
        }

        public Command<DateTime> ChangeDay { get; set; }
        public Command<int> WeekSelect { get; set; }

        private void DataToListView(int week)
        {
            App.Current.MainPage.DisplayAlert("Alert", week.ToString(), "Okay");
        }

        private void StartList(DateTime today)
        {
            skemas.Clear();
            /*fruits.Add(new Fruit() { FruitName = "th", FruitStuff = "mmmmmm" });
            fruits.Add(new Fruit() { FruitName = "bh", FruitStuff = "hhhhhhh" });
            fruits.Add(new Fruit() { FruitName = "er", FruitStuff = "etee" });
            fruits.Add(new Fruit() { FruitName = "Graertpe", FruitStuff = "dfsdafsd" });
            fruits.Add(new Fruit() { FruitName = "Manererego", FruitStuff = "tersss" });
            fruits.Add(new Fruit() { FruitName = "Manererego", FruitStuff = "tersss" });*/
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
    }
}
