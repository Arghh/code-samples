using System;
using System.Globalization;


namespace BankOmant
{
    class Program
    {
        static void Main(string[] args)
        {   //TODO dont accept negative number. restart programm. test values. make a function. 
            //if user enters letters instead of numbers give error
            try
            {
                int m;
                string sum;
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("How many € would you like to withdrawal today?");
                sum = Console.ReadLine();
                m = Int32.Parse(sum);

                //if the entered amout does not devide with 5
                if (m % 5 != 0)
                {
                    Console.WriteLine("We only have 50€, 20€, 10€ and 5€ banknotes available");
                    Console.WriteLine(m + " € is not a correct amount.");
                }
                //if user entered a correct amout
                else
                {
                    //take the sum amout(m) and fits it into 50,20,10 and 5. shows how many of which notes were given. 
                    int firstRemainder; //remainders are the leftover amout
                    int secondRemainder;
                    int thirdRemainder;
                    int fourthRemainder;

                    int numOf50s = (Math.DivRem(m, 50, out firstRemainder));
                    if (numOf50s != 0)
                    {
                        Console.WriteLine("You received " + numOf50s + " 50€");
                    }


                    int numOf20s = (Math.DivRem(firstRemainder, 20, out secondRemainder));
                    if (numOf20s != 0)
                    {
                        Console.WriteLine("You received " + numOf20s + " 20€");
                    }


                    int numOf10s = (Math.DivRem(secondRemainder, 10, out thirdRemainder));
                    if (numOf10s != 0)
                    {
                        Console.WriteLine("You received " + numOf10s + " 10€");
                    }


                    int numOf5s = (Math.DivRem(thirdRemainder, 5, out fourthRemainder));
                    if (numOf5s != 0)
                    {
                        Console.WriteLine("You received " + numOf5s + " 5€");
                    }

                    Console.WriteLine("Have a nice day!");

                }
            }


            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
