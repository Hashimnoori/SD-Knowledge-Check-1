using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck1_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello. Press 1 for addition, 2 for subtraction, 3 for multiplication, and 4 for division");

            var input = Console.ReadLine();
            var calculator = new Calculator();

            switch (input)
            {
                case "1":
                    HandleOperation("addition", calculator.Add);
                    break;

                case "2":
                    HandleOperation("subtraction", calculator.Subtract);
                    break;

                case "3":
                    HandleOperation("multiplication", calculator.Multiply);
                    break;

                case "4":
                    HandleOperation("division", calculator.Divide);
                    break;

                default:
                    Console.WriteLine("Unknown input");
                    break;
            }
        }

        static void HandleOperation(string operationName, Func<int, int, int> operation)
        {
            Console.WriteLine($"Enter 2 integers to {operationName}");
            var Addnumber1 = Console.ReadLine();
            var Addnumber2 = Console.ReadLine();

            if (int.TryParse(Addnumber1, out int numOne) && int.TryParse(Addnumber2, out int numTwo))
            {
                Console.Write($"{Addnumber1} {GetOperator(operationName)} {Addnumber2} = ");
                Console.WriteLine(operation(numOne, numTwo));
            }
            else
            {
                Console.WriteLine("One or more of the numbers is not an int");
            }
        }

        static void HandleOperation(string operationName, Func<double, double, double> operation)
        {
            Console.WriteLine($"Enter 2 numbers to {operationName}");
            var number1 = Console.ReadLine();
            var number2 = Console.ReadLine();

            if (double.TryParse(number1, out double numOne) && double.TryParse(number2, out double numTwo))
            {
                Console.Write($"{number1} {GetOperator(operationName)} {number2} = ");
                Console.WriteLine(operation(numOne, numTwo));
            }
            else
            {
                Console.WriteLine("One or more of the numbers is not a valid number");
            }
        }

        static string GetOperator(string operationName)
        {
            return operationName switch
            {
                "addition" => "+",
                "subtraction" => "-",
                "multiplication" => "*",
                "division" => "/",
                _ => "?",
            };
        }

    }
}