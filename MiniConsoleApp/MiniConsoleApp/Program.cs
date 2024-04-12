using Core.Models;

namespace MiniConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool check = true;
            string choise;
            do
            {
                Console.WriteLine("1.Classroom yarat" +
                    "\n2.Student yarat" +
                    "\n3.Butun Telebeleri ekrana cixart" +
                    "\n4.Secilmis sinifdeki telebeleri ekrana cixart" +
                    "\n5.Telebe sil (Verilmis id olan telbeni taparaq silecek)" +
                    "\n0. EXIT\n");

                choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        break;

                    case "2":
                        break;

                    case "3":
                        break;

                    case "4":
                        break;

                    case "5":
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
