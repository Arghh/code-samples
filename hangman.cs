using System;
using System.Collections.Generic;

namespace hangman
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a word for hangman:");
            char [] word = Console.ReadLine().ToCharArray();
            char [] dummy = new char[word.Length];
            Console.Clear();
            List<char> guessed = new List<char>();
            char a;
            int count = 0;
            for (int x = 0; x < dummy.Length; x++)
            {
                dummy[x] = '_';
            }
            
            do
            {
                Console.WriteLine("Enter a letter:");
                string guess = Console.ReadLine();
                bool result = char.TryParse(guess, out a);
                if (guessed.Contains(a))
                {
                    Console.WriteLine("Already tried it");
                }
                else
                {
                    guessed.Add(a);
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == a)
                        {
                            dummy[i] = a;
                            count++;
                        }
                    }
                }
                Console.Write(dummy);
                foreach (char x in guessed) // Loop through List with foreach.
                {
                    Console.Write("{0}, ",x);
                }
                if (guessed.Count > 3)
                    break;
            } while (count < word.Length);

           
           
                Console.WriteLine("you won");
            

            Console.ReadLine();
            }
 
    }

}
