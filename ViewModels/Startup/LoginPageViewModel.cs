using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
//using CommunityToolkit.Mvvm.Input;
//using CommunityToolkit.Mvvm.ComponentModel;


using Newtonsoft.Json;
using SkoleIT.Controls;
using SkoleIT.Models;
using SkoleIT.Services;
using SkoleIT.Views.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkoleIT.ViewModels.Startup
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;
        [ObservableProperty]
        private string _email; 

        [ObservableProperty]
        private string _password;

        #region Commands
        /* public ICommand Login { get; set; }

         public LoginPageViewModel()
         {
             Login = new Command(Loginnow);
         }*/

        public LoginPageViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [ICommand]
        async void Login()
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
               


                var response = await _loginService.Authenticate(new LoginRequest
                {
                    Login = Email,
                    Password = Password
                });

                var userDetails = new UserBasicInfo
                {
                    Email = Email,
                    
                };


                if (response.userId > 0)
                {
                    //await AppShell.Current.DisplayAlert("Valid User", "Correct", "OK");
                

                    // Student Role, Teacher Role, Admin Role,
                    if (Email.Length > 4)
                    {
                        userDetails.FullName = response.fullName;
                        userDetails.RoleID = (int)RoleDetails.Student;
                        userDetails.RoleText = "Student Role";
                        userDetails.UserId = response.userId;
                        userDetails.UserImage = response.userimage;
                    }
                    else 
                    {
                        userDetails.FullName = response.fullName;
                        userDetails.RoleID = (int)RoleDetails.Teacher;
                        userDetails.RoleText = "Teacher Role";
                        userDetails.UserId = response.userId;
                    }

                    /*string username = Email;
                    string password = Password;

                    string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));

                    request.Headers.Add("Authorization", "Basic " + svcCredentials);*/

                    // calling api 


                    if (Preferences.ContainsKey(nameof(App.UserDetails)))
                    {
                        Preferences.Remove(nameof(App.UserDetails));
                    }

                    string userDetailStr = JsonConvert.SerializeObject(userDetails);
                    Preferences.Set(nameof(App.UserDetails), userDetailStr);
                    App.UserDetails = userDetails;
                    await AppConstant.AddFlyoutMenusDetails();

                }
                else
                {
                    await AppShell.Current.DisplayAlert("Invalid User", "Incorrect", "OK");
                }
            }


        }
        #endregion
    }
}
