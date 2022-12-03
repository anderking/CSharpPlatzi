using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace FundamentosCSharpNetCore21.Util
{
    public static class Printer
    {
        public static void PrintLine(int size = 10)
        {
            WriteLine("".PadLeft(size, '='));
        }

        public static void WriteTitle(string title)
        {
            var size = title.Length + 4;
            PrintLine(size);
            WriteLine($"| {title} |");
            PrintLine(size);
        }

        public static void Beep(int hz = 2000, int time = 500, int cant = 1)
        {
            while (cant-- > 0)
            {
                System.Console.Beep(hz, time);
            }
        }
    }
}
