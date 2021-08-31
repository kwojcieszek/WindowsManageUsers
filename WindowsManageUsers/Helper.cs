using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsManageUsers
{
    public static class Helper
    {
        public static string ReplaceDiacriticsChars(string s)
        {
            s = s.Replace('Ę', 'E');
            s = s.Replace('ę', 'e');
            s = s.Replace('Ó', 'O');
            s = s.Replace('ó', 'o');
            s = s.Replace('Ą', 'A');
            s = s.Replace('ą', 'a');
            s = s.Replace('Ś', 'S');
            s = s.Replace('ś', 's');
            s = s.Replace('Ł', 'L');
            s = s.Replace('ł', 'l');
            s = s.Replace('Ż', 'Z');
            s = s.Replace('ż', 'z');
            s = s.Replace('Ź', 'ź');
            s = s.Replace('ź', 'z');
            s = s.Replace('Ć', 'C');
            s = s.Replace('ć', 'c');
            s = s.Replace('Ń', 'N');
            s = s.Replace('ń', 'n');

            //Niemieckie
            s = s.Replace('ä', 'a');
            s = s.Replace('Ä', 'A');
            s = s.Replace('ö', 'o');
            s = s.Replace('Ö', 'O');
            s = s.Replace('ü', 'u');
            s = s.Replace('Ü', 'U');

            return s;
        }
    }
}
