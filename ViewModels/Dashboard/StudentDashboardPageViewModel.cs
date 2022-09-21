

using Microsoft.Toolkit.Mvvm.Input;
using SkoleIT.Models;
using SkoleIT.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkoleIT.ViewModels.Dashboard
{
    public class StudentDashboardPageViewModel : BaseViewModel
    {
        private readonly StudentCardService _studentCardService;
        public event PropertyChangedEventHandler PropertyChanged;

        private string _fullname, _studentimage, _birth, _school, _unilogin, _enddate;
        
        public string FullName
        {
            get => _fullname; 
            private set
            {
                if (_fullname != value)
                {
                    _fullname = value;
                    OnPropertyChanged();
                }
            }
        }
        public string StudentImage { get => _studentimage;
            private set
            {
                if (_studentimage != value)
                {
                    _studentimage = value;
                    OnPropertyChanged();
                }
            }
        }
        public string School { get => _school;
            private set
            {
                if (_school != value)
                {
                    _school = value;
                    OnPropertyChanged();
                }
            }
        }
        public string UniLogin { get => _unilogin;
            private set
            {
                if (_unilogin != value)
                {
                    _unilogin = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Birth { get => _birth;
            private set
            {
                if (_birth != value)
                {
                    _birth = value;
                    OnPropertyChanged();
                }
            }
        }
        public string EndDate { get => _enddate;
            private set
            {
                if (_enddate != value)
                {
                    _enddate = value;
                    OnPropertyChanged();
                }
            }
        }


        public ICommand AddTextCommand { get; private set; }

        public StudentDashboardPageViewModel(StudentCardService studentCardService)
        {
            _studentCardService = studentCardService;
            int userid = App.UserDetails.UserId;
            var response = _studentCardService.getStudentCard(userid);
            if (response.username != null)
            {
                _fullname = response.Fullname;
                _studentimage = response.picture_path;
                _school = response.workplace;
                DateTime dt = DateTime.ParseExact(response.birthDate.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                string s = 
           
                _birth = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                _unilogin = response.username;

                dt = DateTime.ParseExact(response.education_end.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                _enddate = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            }

        }

        public async void FillPage()
        {
            //int userid = App.UserDetails.UserId;
           // var response = await _studentCardService.getStudentCard(userid);
            //var studentcard = new StudentCard()

            /*if (response.username != null)
            {
                _fullname = response.Fullname;
                _studentimage = response.picture_path;
                _school = response.workplace;
                _birth = response.birthDate;
                _unilogin = response.username;
                _enddate = response.education_end;

            }  */
    
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

       /* public async void OnAppearing()
        {
           FillPage();
        }*/


    }
}
