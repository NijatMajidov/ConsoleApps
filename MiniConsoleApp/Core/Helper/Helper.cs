using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Helper
{
    public static class Helper
    {
        public static bool CheckStudent(this string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                if (word.Split(' ').Length == 1 && word.Length > 3 && char.IsUpper(word[0]))
                {
                    return true;
                }
            }
            return false;
        }


        public static bool CheckGroupName(this string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                if (word.Split(' ').Length == 1 && word.Length == 5)
                {
                    if (char.IsUpper(word[0]) && char.IsUpper(word[1]) && byte.TryParse(word.Substring(2), out byte a))
                        return true;
                }
            }
            return false;
        }

    }
}
