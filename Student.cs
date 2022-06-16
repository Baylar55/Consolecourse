using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Student
    {
        public int ID { get;}
        public static int id;
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        
        public Student()
        {

            ++id;
            ID = id;
        }
        
    }
}
