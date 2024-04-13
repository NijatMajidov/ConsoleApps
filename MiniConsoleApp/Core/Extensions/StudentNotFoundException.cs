using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    internal class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string message = "No students were found with this ID") : base(message)
        {
        }
    }
}
