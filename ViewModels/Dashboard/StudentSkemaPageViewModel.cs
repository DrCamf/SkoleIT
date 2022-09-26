using Microsoft.Toolkit.Mvvm.Input;
using SkoleIT.Controls;
using SkoleIT.Models;
using SkoleIT.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkoleIT.ViewModels.Dashboard
{
    public partial class StudentSkemaPageViewModel : BaseViewModel
    {
        private List<Skema> skemaCollection = new List<Skema>();
        private readonly StudentSkemaService _studentSkemaService;
        

        public StudentSkemaPageViewModel(StudentSkemaService studentSkemaService)
        {
            AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
            _studentSkemaService = studentSkemaService;
            CultureInfo cultures = CultureInfo.GetCultureInfo("de-DE");

            DateTime today = DateTime.Today;
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

        }

        
        [ICommand]
        async void DagCommand()
        {
            DateTime today = DateTime.Today;
            today = today.AddDays(1);
            
        }
        

        public List<Skema> SkemaCollection
        {
            get { return skemaCollection; }
            set { skemaCollection = value; }
        }
    }
}   
