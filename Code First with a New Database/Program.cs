using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_with_a_New_Database
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; }
        public IList<Tag> Tags { get; set; }
    }

    public class Author
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public IList<Course> Courses {get; set; }
    }
   


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
