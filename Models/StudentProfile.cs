using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SkoleIT.Models
{
    public class StudentProfile
    {
        private string _fullname = string.Empty;

        public string username { get; set; }
        public string firstName { get; set; }
        public string sirName { get; set; }
        public string Phone { get; set; }
        public string AltPhone { get; set; }
        public string school_email { get; set; }
        public string private_email { get; set; }
        public string picture_path { get; set; }
        public string birthdate { get; set; }
        public string adress { get; set; }
        public string postNbr { get; set; }
        public string City { get; set; }
        public string School { get; set; }
        public string UddanStart { get; set; }
        public string UddanSlut { get; set; }
        public string ClassName { get; set; }
        public string ClassStart { get; set; }
        public string ClassEnd { get; set; }
        public string absent { get; set; }
        public string Contact { get; set; }

        public string Fullname
        {
            get { return $"{firstName} {sirName}"; }
            set { _fullname = $"{firstName} {sirName}"; }
        }
    }
}
