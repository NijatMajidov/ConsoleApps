using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    internal class Classroom
    {
        static int _id;
        public int Id { get; set; }
        public string Name { get; set; }

        Student[] students;

        public Classroom()
        {
            students = new Student[0];
        }

        public
    }
}
