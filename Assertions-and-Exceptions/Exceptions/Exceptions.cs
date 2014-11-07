using System;
using System.Collections.Generic;
using System.Text;

class Exceptions
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (startIndex >= arr.Length)
        {
            throw new ArgumentOutOfRangeException("startIndex", "The value of starting index is too big.");
        }

        if (count <= 0)
        {
            throw new ArgumentOutOfRangeException("count", "The count should be positive number.");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }
        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException("count", "Invalid count!");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }
        return result.ToString();
    }

    public static void CheckPrime(int number)
    {

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {

            if (number % divisor == 0)
            {
                Console.WriteLine("The number is not prime!");
                return;
            }
        }    
        
        Console.WriteLine("The number is prime!");
    }

    static void Main()
    {
        try
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 5);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("The value of startIndex or count of substring is too big.");
        }

        try
        {
            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));
            Console.WriteLine(ExtractEnding("Hi", 100));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        CheckPrime(23);
        CheckPrime(33);

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
