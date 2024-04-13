using Core.Helper;
using Core.Models;
using System.ComponentModel.Design;

namespace MiniConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            School DataBase = new School("School");
            bool check = true;
            string choise;
            Console.WriteLine("---------------- MENU ----------------");
            do
            {
                Console.WriteLine("\n1. Classroom yarat" +
                    "\n2. Student yarat" +
                    "\n3. Butun Telebeleri ekrana cixart" +
                    "\n4. Secilmis sinifdeki telebeleri ekrana cixart" +
                    "\n5. Telebe sil (Verilmis id olan telbeni taparaq silecek)" +
                    "\n0. EXIT\n");

                choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        Console.WriteLine("Yeni sinif yaratmaq ucun melumatlari daxil edin:\n");
                        string name;
                        do
                        {
                             Console.WriteLine("Sinif adini daxil et:\n");
                             name = Console.ReadLine();
                        } while (!name.CheckGroupName());
                        Type:
                        byte type;
                        Console.WriteLine("\nSinif Type`ni secin:\n" +
                                 "1.Backend\n" +
                                 "2.FrontEnd\n");
                        while(!byte.TryParse(Console.ReadLine(), out type)){
                             Console.WriteLine("Yanliz 1 ve 2!\n");
                        }
                        switch (type)
                        {

                            case 1:
                                Classroom BackClass = new Classroom(name,type);
                                DataBase.AddClassroom(BackClass);
                            break;
                            case 2:
                                Classroom FrontClass = new Classroom(name, type);
                                DataBase.AddClassroom(FrontClass);
                            break;
                            default:
                               Console.WriteLine("Bele bir Type yoxdur!\n");
                            goto Type;
                        }
                    break;

                    case "2":
                        if (DataBase.Classroom.Length == 0) Console.WriteLine("Sinif olmadan Telebe elave ede bilmezsiz");
                        else
                        {
                            Console.WriteLine("Yeni telebe yaratmaq ucun melumatlari daxil edin:\n");
                            string userName;
                            do
                            {
                                Console.WriteLine("Telebe adini daxil et:\n");
                                userName = Console.ReadLine();
                            } while (!userName.CheckStudent());

                            string userSurname;
                            do
                            {
                                Console.WriteLine("Telebe Soyadini daxil et:\n");
                                userSurname = Console.ReadLine();
                            } while (!userSurname.CheckStudent());

                            Student student = new Student(userName, userSurname);
                            
                            Console.WriteLine("Hansi sinife elave edilsin");
                            foreach (Classroom add in DataBase.Classroom)
                            {
                                Console.WriteLine($"{add.Id} | {add.Name}");
                            }

                            string noStr = Console.ReadLine();
                            int no;
                            while(!(int.TryParse(noStr, out no) && no <= DataBase.Classroom.Length))
                            {
                                Console.WriteLine("Duzgun sinifi secin");
                                noStr = Console.ReadLine();
                            }

                            foreach(Classroom add in DataBase.Classroom)
                            {
                                if(add.Id == no)
                                {
                                    add.AddStudent(student);
                                }
                            }
                        }
                    break;

                    case "3":
                        foreach(Classroom classroom in DataBase.Classroom)
                        {
                            Console.WriteLine(classroom.Name+ ":");
                            classroom.ShowStudents();
                        }
                        break;

                    case "4":
                        Console.WriteLine("Hansi sinif ekrana cixarilsin");
                        foreach (Classroom add in DataBase.Classroom)
                        {
                            Console.WriteLine($"{add.Id} | {add.Name}");
                        }

                        string idStr = Console.ReadLine();
                        int id;
                        while (!(int.TryParse(idStr, out id) && id <= DataBase.Classroom.Length))
                        {
                            Console.WriteLine("Duzgun sinifi secin");
                            idStr = Console.ReadLine();
                        }

                        foreach (Classroom classroom in DataBase.Classroom)
                        {
                            if (classroom.Id == id)
                            {
                                classroom.ShowStudents();
                            }
                        }
                        break;

                    case "5":
                        Console.WriteLine("Hansi sinifden telebe silinsin");
                        foreach (Classroom add in DataBase.Classroom)
                        {
                            Console.WriteLine($"{add.Id} | {add.Name}");
                        }

                        string idSt = Console.ReadLine();
                        int iddel ;
                        while (!(int.TryParse(idSt, out iddel) && iddel <= DataBase.Classroom.Length))
                        {
                            Console.WriteLine("Duzgun sinifi secin");
                            idSt = Console.ReadLine();
                        }
                        string strDel;
                        int del;
                        foreach (Classroom classroom in DataBase.Classroom)
                        {
                            if (classroom.Id == iddel)
                            {
                                Console.WriteLine("silinecek telebe id sini daxil edin:");
                                strDel = Console.ReadLine();
                                while (!(int.TryParse(strDel, out del) && del <= classroom.Students.Length))
                                {
                                    Console.WriteLine("Duzgun telebe secin");
                                    strDel = Console.ReadLine();
                                }

                                classroom.Delete(del);
                            }
                        }
                        break;
                    
                    case "0":
                        check = false;
                        Console.WriteLine("~Program bitti!~");
                    break;

                    default:
                        Console.WriteLine("~Bele bir secim yoxdur!~\n");
                    break;
                }
            } while (check);
        }
    }
}
