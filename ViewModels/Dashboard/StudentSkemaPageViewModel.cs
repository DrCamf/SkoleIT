
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using Microsoft.Toolkit.Mvvm.Input;
using SkoleIT.Controls;
using SkoleIT.Models;
using SkoleIT.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkoleIT.ViewModels.Dashboard
{
    public partial class StudentSkemaPageViewModel : BaseViewModel
    {
        

        private List<Skema> skemaCollection = new List<Skema>();
        private readonly StudentSkemaService _studentSkemaService;

        public event PropertyChangedEventHandler PropertyChanged;
        
        private DateTime _monday, _tuesday, _wednesday, _thursday, _friday;
        public List<Skema> SkemaCollection
        {
            get { return skemaCollection; }
            set { skemaCollection = value; }
        }

        public DateTime Monday
        {
            get => _monday;
            private set
            {
                if (_monday != value)
                {
                    _monday = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime Tuesday
        {
            get => _tuesday;
            private set
            {
                if (_tuesday != value)
                {
                    _tuesday = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime Wednesday
        {
            get => _wednesday;
            private set
            {
                if (_wednesday != value)
                {
                    _wednesday = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime Thursday
        {
            get => _thursday;
            private set
            {
                if (_thursday != value)
                {
                    _thursday = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime Friday
        {
            get => _friday;
            private set
            {
                if (_friday != value)
                {
                    _friday = value;
                    OnPropertyChanged();
                }
            }
        }

       

        public StudentSkemaPageViewModel(StudentSkemaService studentSkemaService)
        {
            AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
            _studentSkemaService = studentSkemaService;

            CultureInfo cultures = CultureInfo.GetCultureInfo("de-DE");

            

            NewDay = new Command<DateTime>(FillSkema);

            DateTime today = DateTime.Today;
            //today = today.AddDays(3);


            FillSkema(today);

        }


        private void GetWeekDays(DateTime today) 
        {

            switch (today.ToString("dddd")) 
            {
                case "Monday":
                    _monday = today;
                    _tuesday = today.AddDays(1);
                    _wednesday = today.AddDays(2);
                    _thursday = today.AddDays(3);
                     _friday = today.AddDays(4);
                    break;
                case "Tuesday":
                    _monday = today.AddDays(-1);
                    _tuesday = today;
                    _wednesday = today.AddDays(1);
                    _thursday = today.AddDays(2);
                    _friday = today.AddDays(3);
                    break;
                case "Wednesday":
                    _monday = today.AddDays(-2);
                    _tuesday = today.AddDays(-1);
                    _wednesday = today;
                    _thursday = today.AddDays(1);
                    _friday = today.AddDays(2);
                    break;
                case "Thursday":
                    _monday = today.AddDays(-3);
                    _tuesday = today.AddDays(-2);
                    _wednesday = today.AddDays(-1);
                    _thursday = today;
                    _friday = today.AddDays(1);
                    break;
                case "Friday":
                    _monday = today.AddDays(-4);
                    _tuesday = today.AddDays(-3);
                    _wednesday = today.AddDays(-2);
                    _thursday = today.AddDays(-1);
                    _friday = today;
                    break;



            }
        
        }

       /* bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }*/

        private void FillSkema(DateTime today)
        {
           
            skemaCollection.Clear();
           
            int userid = App.UserDetails.UserId;
            
            var response = _studentSkemaService.GetSkemaByDate(today, userid);
            foreach (Skema skema in response.ToArray())
            {
                if (skema != null)
                {
                    skema.Start = skema.ClassBegin.ToString("H:mm");
                    skema.End = skema.ClassEnd.ToString("H:mm");
                }
                skemaCollection.Add(skema);
            }
            App.Current.MainPage.DisplayAlert("Alert", response.Count().ToString(), "Okay");
            //PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SkemaCollection)));
            //IsRefreshing = false;
        }
        public Command<DateTime> NewDay { get; set; }


        
    }

}   
