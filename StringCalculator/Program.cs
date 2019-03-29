using System;
using System.Collections.Generic;

namespace StringCalculatorNamespace
{
    public class StringCalculator
    {
        static void Main(string[] args)
        {

            string number = "";
            List<string> numbers = new List<string> { };
            do
            {
                number = Console.ReadLine()+Environment.NewLine;
                numbers.Add(number);

            } while (number != Environment.NewLine);

            StringCalculator sc = new StringCalculator();
            int result = sc.Add(numbers);

            Console.WriteLine(result.ToString());

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

        public int Add(List<string> numbers)
        {
            int result = 0;
            /* ',' default delimiter */
            string[] tempdelimiter = {","};
            string[] delimiter = { "," };
            /* // control code in beginning to define custom delimiter */
            string controlcode = "//"; 

            foreach (string str in numbers)
            {
                if (str != "\r\n")
                {
                    if (str.StartsWith(controlcode))
                    {
                        string tstr = str.Remove(0, 2).Remove(str.Length - 4, 2);
                        delimiter = tstr.Split(tempdelimiter, StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    string[] num = str.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string item in num)
                    {
                        if (item != "\r\n")
                        {
                            try
                            {
                                int i = int.Parse(item);

                                if (i > 0)
                                {
                                    if (i <= 1000)
                                        result += i;
                                }
                                else
                                    throw new System.ArgumentException("Negatives not allowed " + item);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Exception encountered: " + ex.Message);

                                // Keep the console window open in debug mode.
                                Console.WriteLine("Press any key to exit.");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                    }
                }
            }


            return result;
        }

    }
}
