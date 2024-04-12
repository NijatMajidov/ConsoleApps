using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Classroom
    {
        static int _id;
        public int Id { get; set; }
        public string Name { get; set; }

        Student[] students;

        public ClassType ClassType { get; set; }

        int _limit;
        public Classroom(string name, byte type)
        {
            students = new Student[0];
            Id = ++_id;
            Name = name;
            if(type == 1)
            { 
                _limit = 20;
                ClassType = ClassType.Backend;
            }
            else if (type == 2) 
            {
                _limit = 15;
                ClassType = ClassType.FrontEnd;
            }
            else Console.WriteLine("Bele bir Type yoxdur");

        }

        public void StudentAdd(Student student)
        {
            if (_limit >= students.Length) Console.WriteLine("Doludur!");
            else{
                Array.Resize(ref students, students.Length + 1);
                students[students.Length - 1] = student;
                Console.WriteLine($"{student.Name} ugurla departmente elave edildi\n");
            }

        }

        public Student FindId(int id)
        {

            foreach(Student student in students)
            {
                if(student.Id == id)
                {
                    return student;
                }
            }

            return null;
        }

        public void Delete(int id)
        {
            Student[] newStudents = { };
            foreach(Student student in students)
            {
                if(student.Id != id)
                {
                    Array.Resize(ref newStudents, newStudents.Length + 1);
                    newStudents[newStudents.Length - 1] = student;
                }
            }

            students = newStudents;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {ClassType} {_limit}";
        }
    }
}
