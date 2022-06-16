using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Group
    {
        public string Name { get; set; }

        public List<Student> students ;
        
        public Group()
        {
            students = new List<Student>();
           
        }
        
    }
}
