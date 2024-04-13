using Core.Enums;
using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Classroom
    {
        static int _id;
        public int Id { get;}
        public string Name { get; set; }
        public ClassType ClassType { get; set; }

        public Student[] Students;

        public int Limit;
        public Classroom(string name, byte type)
        {
            Id = ++_id;
            Students = new Student[0];
            Name = name;
            if(type == 1)
            { 
                Limit = 20;
                ClassType = ClassType.Backend;
            }
            else if (type == 2) 
            {
                Limit = 15;
                ClassType = ClassType.FrontEnd;
            }

            Console.WriteLine($"Yeni {Name} sinifi yaradildi\n");

        }

        public void AddStudent(Student student)
        {
            if (Limit < Students.Length+1) Console.WriteLine("Doludur!");
            else{
                Array.Resize(ref Students, Students.Length + 1);
                Students[Students.Length - 1] = student;
                Console.WriteLine($"{student.Name} ugurla {Name}-e elave edildi\n");
            }

        }

        public Student FindId(int id)
        {

            foreach(Student student in Students)
            {
                if(student.Id == id)
                    return student;
            }

            throw new StudentNotFoundException();
        }

        public void Delete(int id)
        {
            Student[] newStudents = { };
            foreach(Student student in Students)
            {
                if(student.Id != id)
                {
                    Array.Resize(ref newStudents, newStudents.Length + 1);
                    newStudents[newStudents.Length - 1] = student;
                }
            }
            if (newStudents.Length == Students.Length) throw new StudentNotFoundException();
            Students = newStudents;
        }

        public void ShowStudents()
        {
            foreach (Student student in Students) Console.WriteLine(student);
        }

        public override string ToString()
        {
            return $"{Id} | {Name} | {ClassType} | {Limit}";
        }
    }
}
