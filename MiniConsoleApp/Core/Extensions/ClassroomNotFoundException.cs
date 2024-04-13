using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    internal class ClassroomNotFoundException : Exception
    {
        public ClassroomNotFoundException(string message = "Classroom Not Found") : base(message)
        {
        }
    }
}
