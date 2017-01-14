using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

/*
 * Write a program that calculates the value of given arithmetical expression. The expression can contain the following elements only:
Real numbers, e.g. 5, 18.33, 3.14159, 12.6
Arithmetic operators: +, -, *, / (standard priorities)
Mathematical functions: ln(x), sqrt(x), pow(x,y)
Brackets (for changing the default priorities)
	Examples:
	(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)  ~ 10.6
	pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)  ~ 21.22
	Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation".
*/

class Program
{
    static bool CheckBraclets(List<string> equation)
    {
        for (int i = 0; i < equation.Count(); i++)
		{
            if (equation[i].Equals("("))
            {
                for (int y = i + 1; y < equation.Count(); y++)
                {
                    if (equation[y].Equals("("))
                    {
                        Console.WriteLine("The program does not support braclets in braclets");
                        return false;
                    }
                    else if (equation[y].Equals(")"))
                    {
                        break;
                    }
                    else if (y == equation.Count() - 1)
                    {
                        Console.WriteLine("A braclet is not closed");
                        return false;
                    }
                }
            }
		}
        return true;
    }

    static bool CheckLogic(List<string> equation)
    {
        double temp;
        string[] specialsSymbols = { "ln", "pow", "sqrt" };
        string[] symbols = { "-", "+", "*", "/" };

        for (int i = 0; i < equation.Count(); i++)
        {
            if (double.TryParse(equation[i], out temp) && i < equation.Count()-1)
            {
                if (double.TryParse(equation[i + 1], out temp))
                { Console.WriteLine("Wrong Logic! 1"); return false; }
                else if (equation[i + 1].Equals("("))
                { Console.WriteLine("Wrong Logic! 2"); return false; }
            }
            for (int y = 0; y < specialsSymbols.Length; y++)
            {
                if (equation[i].Equals(specialsSymbols[y]))
                {
                    if (i + 1 == equation.Count())
                    { Console.WriteLine("Wrong Logic! 3"); return false; }

                    for (int z = 0; z < specialsSymbols.Length; z++)
                        if (equation[i+1].Equals(specialsSymbols[z]))
                        { Console.WriteLine("Wrong Logic! 4"); return false; }
                    for (int z = 0; z < symbols.Length; z++)
                        if (equation[i + 1].Equals(symbols[z]))
                        { Console.WriteLine("Wrong Logic! 5"); return false; }
                }
            }
            for (int z = 0; z < symbols.Length; z++)
            {
                if (equation[i].Equals(symbols[z]))
                {
                    if (i+1 == equation.Count())
                        { Console.WriteLine("Wrong Logic! 6"); return false; }

                    for (int y = 0; y < symbols.Length; y++)
                        if (equation[i+1].Equals(symbols[y]))
                        { Console.WriteLine("Wrong Logic! 7"); return false; }
                }
            }
        }
        return true;
    }

    static List<string> Calculate(List<string> equation, int start, int end)
    {
        if (equation[start].Equals("(") && equation[end].Equals(")")) // remove braclets
        {
            equation.RemoveAt(end);        ///  5 * ( 5 + 2 )  >>> 5 * 5 + 2
            equation.RemoveAt(start);       //      ^       ^   |      ^   ^
            end-=2;                         //     start   end  |   start  end
        }

        for (int i = start; i <= end-1; i++)
        {
            if (equation[i].Equals("ln"))
            {
                equation[i] = Math.Log(double.Parse(equation[i + 1])).ToString();

                equation.RemoveAt(i + 1);
                end--;
            }
            if (equation[i].Equals("pow"))
            {
                equation[i] = Math.Pow(double.Parse(equation[i + 2]), double.Parse(equation[i + 4])).ToString();
                for (int y = 1; y <= 5; y++)  //// pow ( 3 , 2 ) >>> 9 ( 3 , 2 ) >>> 9
                {                               //  ^  ^ ^ ^ ^ ^     ^ ^ ^ ^ ^ ^     ^
                    equation.RemoveAt(i + 1);   //  0  1 2 3 4 5 >>> 0 1 2 3 4 5     0
                    end--;
                }
            }
            if (equation[i].Equals("sqrt"))
            {
                equation[i] = Math.Sqrt(double.Parse(equation[i + 1])).ToString();

                equation.RemoveAt(i + 1);
                end--;
            }
        }

        for (int i = start; i <= end; i++)
        {
            if (equation[i].Equals("*"))
            {
                equation[i] = (double.Parse(equation[i - 1]) * double.Parse(equation[i + 1])).ToString();
                equation.RemoveAt(i - 1);
                i--;
                end--;
                equation.RemoveAt(i + 1);
                end--;
            }
            if (equation[i].Equals("/"))
            {
                equation[i] = (double.Parse(equation[i - 1]) / double.Parse(equation[i + 1])).ToString();
                equation.RemoveAt(i - 1);
                i--;
                end--;
                equation.RemoveAt(i + 1);
                end--;
            }

        }
        for (int i = start; i <= end; i++)
        {
            if (equation[i].Equals("+"))
            {
                equation[i] = (double.Parse(equation[i - 1]) + double.Parse(equation[i + 1])).ToString();
                equation.RemoveAt(i - 1);
                i--;
                end--;
                equation.RemoveAt(i + 1);
                end--;
            }

            if (equation[i].Equals("-"))
            {
                equation[i] = (double.Parse(equation[i - 1]) - double.Parse(equation[i + 1])).ToString();
                equation.RemoveAt(i - 1);
                i--;
                end--;
                equation.RemoveAt(i + 1);
                end--;
            }
        }

        return equation;
    }

    static void Main()
    {
       while (true)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            Console.Write("input equation: ");
            string eqStr = Console.ReadLine().Replace(" ", "").ToLower();
            List<string> equation = new List<string>();
            double tempNum = 0;

            for (int i = 0; i < eqStr.Length; i++)
            {
                
                if (double.TryParse(eqStr.Substring(i, 1), out tempNum))
                {
                    equation.Add(eqStr.Substring(i, 1));
                    for (int y = i+1; y < eqStr.Length; y++)
                    {
                        bool isNaN = false;
                        switch (eqStr.Substring(y, 1))
                        {
                            case ".":
                            case "0":
                            case "1":
                            case "2":
                            case "3":
                            case "4":
                            case "5":
                            case "6":
                            case "7":
                            case "8":
                            case "9":
                                equation[equation.Count - 1] += eqStr.Substring(y, 1);
                                break;

                            default: isNaN = true; break;
                        }
                        if (isNaN) { i = y - 1; break; }
                        i = y;
                    }
                }

                if (eqStr.Substring(i, 1).Equals("l"))
                    if (eqStr.Substring(i, 2).Equals("ln"))
                    { equation.Add(eqStr.Substring(i, 2)); i += 1; }

                if (eqStr.Substring(i, 1).Equals("p"))
                    if (eqStr.Substring(i, 3).Equals("pow"))
                    { equation.Add(eqStr.Substring(i, 3)); i += 2; }

                if (eqStr.Substring(i, 1).Equals("s"))
                    if (eqStr.Substring(i, 2).Equals("sqrt"))
                    { equation.Add(eqStr.Substring(i, 4)); i += 3; }

                switch (eqStr.Substring(i, 1))
                {
                    case "(":
                    case ")":
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case ",":
                        equation.Add(eqStr.Substring(i, 1));
                        break;

                    default: break;
                }
            
            }
            Console.WriteLine(string.Join(" ", equation) + " = ");

            if (!CheckBraclets(equation)) { continue; }
            if (!CheckLogic(equation)) { continue; }

            for (int i = 0; i < equation.Count(); i++)
            {
                if (equation[i].Equals("pow"))
                {
                    Console.WriteLine("pow");
                    equation = Calculate(equation, i, i+5);
                    Console.WriteLine(string.Join(" ", equation) + " = ");
                }
                
                if (equation[i].Equals("("))
                {
                    for (int y = i+1; y < equation.Count(); y++)
                        if (equation[y].Equals(")"))
                        {
                            Console.WriteLine("braclets");
                            equation = Calculate(equation, i, y);
                            Console.WriteLine(string.Join(" ", equation) + " = ");
                            break;
                        }
                }
            }

            Console.WriteLine("finally");
            equation = Calculate(equation, 0, equation.Count() - 1);
            Console.WriteLine(string.Join(" ", equation));

            Console.WriteLine("\n\n\n   Press [enter] to restart.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
