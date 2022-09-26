
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkoleIT.Models
{
    public class Skema
    {
        //public int Id { get; set; }
        public string Fag { get; set; }
        public string Room { get; set; }
        public string Teacher { get; set; }
        public DateTime ClassBegin { get; set; }
        public DateTime ClassEnd { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        //public string studentId { get; set; }

        public Skema(string fag, string room, string teacher, DateTime classBegin, DateTime classEnd, string start, string end)        {
            Fag = fag;
            Room = room;
            Teacher = teacher;
            ClassBegin = classBegin;
            ClassEnd = classEnd;
            Start = start;
            End = end;
        }
       

    }
}
