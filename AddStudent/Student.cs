using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddStudent
{
    public class Student
    {
       public Guid GuidStudent= Guid.NewGuid();
        public string FullName { get; set; }
        public string Group1 { get; set; }
    }
}
