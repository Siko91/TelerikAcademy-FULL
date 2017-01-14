using System;
using System.Collections.Generic;
using System.Linq;

namespace DefensivePrograming.Exceptions
{
    public class ExceptionTest
    {
        public static void RunTest()
        {
            try
            {
                var substr = ExceptionsHomework.Subsequence("Hello!".ToCharArray(), 2, 3);
                Console.WriteLine(substr);
            }
            catch (ArgumentOutOfRangeException aorex)
            {
                Console.WriteLine(aorex.Message);
            }

            try
            {
                var subarr = ExceptionsHomework.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
                Console.WriteLine(String.Join(" ", subarr));
            }
            catch (ArgumentOutOfRangeException aorex)
            {
                Console.WriteLine(aorex.Message);
            }

            try
            {
                var allarr = ExceptionsHomework.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
                Console.WriteLine(String.Join(" ", allarr));
            }
            catch (ArgumentOutOfRangeException aorex)
            {
                Console.WriteLine(aorex.Message);
            }

            try
            {
                var emptyarr = ExceptionsHomework.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
                Console.WriteLine(String.Join(" ", emptyarr));
            }
            catch (ArgumentOutOfRangeException aorex)
            {
                Console.WriteLine(aorex.Message);
            }

            try
            {
                Console.WriteLine(ExceptionsHomework.ExtractEnding("I love C#", 2));
            }
            catch (ArgumentOutOfRangeException aorex)
            {
                Console.WriteLine(aorex.Message);
            }

            try
            {
                Console.WriteLine(ExceptionsHomework.ExtractEnding("Nakov", 4));
            }
            catch (ArgumentOutOfRangeException aorex)
            {
                Console.WriteLine(aorex.Message);
            }

            try
            {
                Console.WriteLine(ExceptionsHomework.ExtractEnding("beer", 4));
            }
            catch (ArgumentOutOfRangeException aorex)
            {
                Console.WriteLine(aorex.Message);
            }

            try
            {
                Console.WriteLine(ExceptionsHomework.ExtractEnding("Hi", 100));
            }
            catch (ArgumentOutOfRangeException aorex)
            {
                Console.WriteLine(aorex.Message);
            }

            Console.WriteLine(ExceptionsHomework.CheckPrime(23));
            Console.WriteLine(ExceptionsHomework.CheckPrime(33));

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
}
