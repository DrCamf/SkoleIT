using SkoleIT.Controls;
using SkoleIT.Models;
using SkoleIT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkoleIT.ViewModels.Dashboard
{
    public partial class StudentGradesPageViewModel : BaseViewModel
    {
        private List<Grades> gradesCollection = new List<Grades>();
        private readonly StudentGradesService _studentgradesservice;

        public StudentGradesPageViewModel(StudentGradesService studentGradesService)
        {
           // AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
            _studentgradesservice = studentGradesService;

            int userid = App.UserDetails.UserId;
            var response = _studentgradesservice.GetGrades(userid);
            foreach (Grades grade in response.ToArray())
            {
               
                gradesCollection.Add(grade);
            }
        }

        public List<Grades> GradesCollection
        {
            get { return gradesCollection; }
            set { gradesCollection = value; }
        }
    }
}
