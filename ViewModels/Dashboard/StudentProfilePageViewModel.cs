using SkoleIT.Controls;
using SkoleIT.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkoleIT.ViewModels.Dashboard
{
    public partial class StudentProfilePageViewModel : BaseViewModel
    {
        private readonly StudentProfileService _studentProfileService;
        private string _fullname, _studentimage, _birth, _school, _unilogin, _Phone, _AltPhone, _school_email, _private_email,  _adress, _postNbr, _City, _UddanStart
    , _UddanSlut, _ClassName, _ClassStart, _ClassEnd, _absent, _contact;

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
        public string Contact
        {
            get => _contact;
            private set
            {
                if (_contact != value)
                {
                    _contact = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Absent
        {
            get => _absent;
            private set
            {
                if (_absent != value)
                {
                    _absent = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ClassName
        {
            get => _ClassName;
            private set
            {
                if (_ClassName != value)
                {
                    _ClassName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ClassStart
        {
            get => _ClassStart;
            private set
            {
                if (_ClassStart != value)
                {
                    _ClassStart = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ClassEnd
        {
            get => _ClassEnd;
            private set
            {
                if (_ClassEnd != value)
                {
                    _ClassEnd = value;
                    OnPropertyChanged();
                }
            }
        }


        public string Adress
        {
            get => _adress;
            private set
            {
                if (_adress != value)
                {
                    _adress = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Post
        {
            get => _postNbr;
            private set
            {
                if (_postNbr != value)
                {
                    _postNbr = value;
                    OnPropertyChanged();
                }
            }
        }
        public string City
        {
            get => _City;
            private set
            {
                if (_City != value)
                {
                    _City = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Phone
        {
            get => _Phone;
            private set
            {
                if (_Phone != value)
                {
                    _Phone = value;
                    OnPropertyChanged();
                }
            }
        }
        public string PhoneAlt
        {
            get => _AltPhone;
            private set
            {
                if (_AltPhone != value)
                {
                    _AltPhone = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EmailSchool
        {
            get => _school_email;
            private set
            {
                if (_school_email != value)
                {
                    _school_email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EmailAlt
        {
            get => _private_email;
            private set
            {
                if (_private_email != value)
                {
                    _private_email = value;
                    OnPropertyChanged();
                }
            }
        }


        public string StudentImage
        {
            get => _studentimage;
            private set
            {
                if (_studentimage != value)
                {
                    _studentimage = value;
                    OnPropertyChanged();
                }
            }
        }
        public string School
        {
            get => _school;
            private set
            {
                if (_school != value)
                {
                    _school = value;
                    OnPropertyChanged();
                }
            }
        }
        public string UniLogin
        {
            get => _unilogin;
            private set
            {
                if (_unilogin != value)
                {
                    _unilogin = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Birth
        {
            get => _birth;
            private set
            {
                if (_birth != value)
                {
                    _birth = value;
                    OnPropertyChanged();
                }
            }
        }
        public string EndDate
        {
            get => _UddanSlut;
            private set
            {
                if (_UddanSlut != value)
                {
                    _UddanSlut = value;
                    OnPropertyChanged();
                }
            }
        }

        public string StartdDate
        {
            get => _UddanStart;
            private set
            {
                if (_UddanStart != value)
                {
                    _UddanStart = value;
                    OnPropertyChanged();
                }
            }
        }

        public StudentProfilePageViewModel(StudentProfileService studentProfileService)
        {
            AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
            _studentProfileService = studentProfileService;

            string user = App.UserDetails.Email;
            var response = _studentProfileService.GetStudentInfo(user);

            if (response.firstName != null)
            {
                _fullname = response.Fullname;
                _studentimage = response.picture_path;
                _school = response.School;
                _adress = response.adress;
                _postNbr = response.postNbr;
                _City = response.City;
                _Phone = response.Phone;
                _AltPhone = response.AltPhone;
                _private_email = response.private_email;
                _school_email = response.school_email;
                _ClassName = response.ClassName;
                _contact = response.Contact;
                _unilogin = response.username;
                _absent = response.absent;
                DateTime dt = DateTime.ParseExact(response.birthdate.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                _birth = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                
                
                dt = DateTime.ParseExact(response.UddanStart.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                _UddanStart = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                dt = DateTime.ParseExact(response.UddanSlut.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                _UddanSlut = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                dt = DateTime.ParseExact(response.ClassStart.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                _ClassStart = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                dt = DateTime.ParseExact(response.ClassEnd.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                _ClassEnd = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            }
           
        }
    }
}
