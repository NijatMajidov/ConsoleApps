using System.Threading.Channels;

namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();
            
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Reverse();
            list.ForEach(Console.WriteLine);
            Console.WriteLine("_----------------------");

            List<int> list2 = new List<int>();
            list2.Add(1);
            list2.Add(2);
            list2.Add(3);
            list.AddRange(list2);
            list.ForEach(Console.WriteLine);
        }
    }
}
