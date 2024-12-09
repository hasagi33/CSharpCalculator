// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator=Calculator.Instance;
            string userX = "0";
            while (userX!="4")
            {
                Console.WriteLine("Calculator Menu:\r\n 1. Perform Basic Calculation \r\n 2. Calculate Square Root\r\n 3. View History\r\n 4. Exit\r\n");
                userX = Console.ReadLine();
                switch (userX)
                {
                    case "1":
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Enter your calculation, number (+,-,/,*) number. exit to return");
                                string userExpression = Console.ReadLine();
                                if (userExpression == "exit")
                                {
                                    break;
                                }

                                Console.WriteLine("Result: "+calculator.calculate(userExpression));
                                // because c# doesnt allow escaping characters, we need to set options as relaxed
                                calculator.addHistory();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Bad input");
                            }
                        }
                        break;
                    case "2":
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Enter your number to Square Root of, exit to return:");
                                string userExpression = Console.ReadLine();
                                if (userExpression == "exit")
                                {
                                    break;
                                }
                                Console.WriteLine("Result: "+calculator.sqrt(userExpression));
                                calculator.addHistory();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Bad input");
                            }
                        }
                        break;
                    case "3":
                        calculator.readHistory();
                        break;
                    case "4":
                        break;
                }
            }
            
            
            Console.WriteLine("byebye");
        }
    }
}