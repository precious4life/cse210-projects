using System;

class Program
{
    static void Main(string[] args)
    {   Console.WriteLine("precious");
        //calling the random module
        Random randomGen = new Random();

        //setting the random number range
        int magicNumber = randomGen.Next(1, 2);

        //Console.WriteLine("Welcome to our mestries series, let see your brain level.");
        //Console.Write("Guess a number from 1-100 ");

        int guessNum = -1;
        //guessNum = Convert.ToInt32(Console.ReadLine());

        while (guessNum != magicNumber)
        {   
            Console.Write("What is your guess: ");
            guessNum = int.Parse(Console.ReadLine());

            if (guessNum < magicNumber){
                Console.WriteLine("Guess highier next time");
            }

            else if (guessNum > magicNumber){
                Console.WriteLine("guess lower next time");
            }
            else
            {
                Console.WriteLine("Welldone");
                }
        }

    }
}