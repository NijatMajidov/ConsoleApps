using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace JsonAndXml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // JSON
            // Serialize
            Person person = new Person
            {
                Name = "Admin",
                Surname = "Admin",
                Age = 30,
                IsStudent = true,
                heightCm = 170,
            };

            string jsonString = JsonSerializer.Serialize(person);
            Console.WriteLine(jsonString);

            // Deserialize
            string jsonStringD = "{\"Name\":\"Admin\",\"Age\":30}";
            Person person2 = JsonSerializer.Deserialize<Person>(jsonStringD);
            Console.WriteLine($"Name: {person2.Name}, Age: {person2.Age}");

            // XML
            // Serialize
            Person newPerson = new Person { Name = "John", Age = 30 };
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, newPerson);
                string xmlString = writer.ToString();
                Console.WriteLine(xmlString);
            }

            // Deserialize
            string xmlString2 = "<Person><Name>John</Name><Age>30</Age></Person>";
            XmlSerializer serializer2 = new XmlSerializer(typeof(Person));
            using (StringReader reader = new StringReader(xmlString2))
            {
                Person newPerson2 = (Person)serializer2.Deserialize(reader);
                Console.WriteLine($"Name: {newPerson2.Name}, Age: {newPerson2.Age}");
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public bool IsStudent { get; set; }
        public byte heightCm { get; set; }
    }
}
