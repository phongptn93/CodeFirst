using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFristProject
{
    public class Standard
    {
        public Standard()
        {
            Student = new HashSet<Student>();

        
        }
        public int StandardId { get; set; }
        public string StandardName { get; set; }
        public virtual ICollection<Student> Student { get; set; }
   
    } 
}
