using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public static class Helper
    {
        public static bool CheckStudent(this string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                if (word.Split(' ').Length==1 && word.Length > 3 && char.IsUpper(word[0]) )
                {
                    return true;
                }
            }
            return false;
        }
    }
}
