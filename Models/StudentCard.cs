using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkoleIT.Models
{
    public class StudentCard
    {
        private string _fullname = string.Empty;
        private string _studentimage = string.Empty;
        private string _school = string.Empty;
        private string _unilogin = string.Empty;
        private string _birth = string.Empty;
        private string _enddate = string.Empty;

        public string firstName { get; set; }
        public string sirName { get; set; }
        public string picture_path { get; set; } 
        /*{ 
            get { return _studentimage; }
            set { _studentimage = value; } 
        }*/
        public string username { get; set; }
       /* {
            get { return _unilogin; }
            set { _unilogin = value; }
        }*/
        public string birthDate { get; set; }
       /* {
            get { return _birth; }
            set { _birth = value; }
        }*/
        public string workplace { get; set; }
        /*{
            get { return _school; }
            set { _school = value; }
        }*/
        public string education_end { get; set; }
        /*{
            get { return _enddate; }
            set { _enddate = value; }
        }*/

        public string Fullname
        {
            get { return $"{firstName} {sirName}";}
            set { _fullname = $"{firstName} {sirName}"; } 
        }

       /* public StudentCard(string firstname, string sirname, string picture, string userName, string birth, string school, string enddate)
        {
            firstName = firstname;
            sirName = sirname;
            picture_path = picture;
            username = userName;
            birthDate = birth;
            workplace = school;
            education_end = enddate;

        }*/


    }
}
