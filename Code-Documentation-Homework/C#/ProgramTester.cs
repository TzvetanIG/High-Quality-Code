using System;
using System.Globalization;
using System.Linq;

class ProgramTester
{
    static void Main(string[] args)
    {
        Console.WriteLine("1258".ToShort());
        Console.WriteLine("1258".ToBoolean());
        Console.WriteLine("2014/13/1".ToDateTime());
        Console.WriteLine("a hkkkh a".GetStringBetween("a", "a"));
        Console.WriteLine("ceco12*4".GetFirstCharacters(5));
    }
}

