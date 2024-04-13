using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class School
    {
        static int _id;
        public int Id;
        public string Name;
        public Classroom[] Classroom;

        public School(string name)
        {
            Classroom = new Classroom[0];
            Id = ++_id;
            Name = name;
        }

        public void AddClassroom(Classroom classroom)
        {
            Array.Resize(ref Classroom, Classroom.Length+1);
            Classroom[Classroom.Length-1]=classroom;
            Console.WriteLine($"{classroom.Name} ugurla {Name}-a elave edildi\n");
        }

        public override string ToString()
        {
            return $"{Id} | {Name}";
        }
    }
}
