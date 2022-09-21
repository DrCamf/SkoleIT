using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkoleIT.Models
{
    public class Grades
    {
        public string FAG { get; set; }
        public string level { get; set; }
        public string grades { get; set; }
        public string TYPE { get; set; }
        public string date { get; set; }

        public Grades(string fag, string niveau, string grade, string type)
        {
            FAG = fag;
            level = niveau;
            grades = grade;
            TYPE = type;
           
        }

        /*public Grades()
        {

        }*/
    }
}
