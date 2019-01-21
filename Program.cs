using System;

namespace P1_44663_NDambadeniya
{
    class Program
    {
        static void Main(string[] args)
        {
           var item = String.Empty;
            var name = String.Empty;
            var moneyToEarn = 0.0M;
            var gender = ' ';

            Console.Clear();
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine("+ PLAY TO WIN A PRISE +");
            Console.WriteLine("+++++++++++++++++++++++");
            Console.Write("What is your name : ");
            name = Console.ReadLine();
            Console.Write("What is your gender (M/F) :");
            gender = Convert.ToChar(Console.ReadLine());
            while (item != "Computer" && item != "Tablet" && item != "Phone")
            {
                Console.Write("\nType one item you want to win (Phone\tTablet\tor Computer)? :");
                item = Console.ReadLine();
            }

            switch (item)
            {
                case "Phone":
                    moneyToEarn = 10.00M;
                    Console.WriteLine($"\nYou need to earn {moneyToEarn} dollers to win a phone");
                    PlayGame(moneyToEarn);
                    break;

                case "Tablet":
                    moneyToEarn = 15.00M;
                    Console.WriteLine($"\nYou need to earn {moneyToEarn} dollers to win a Tablet");
                    PlayGame(moneyToEarn);
                    break;

                case "Computer":
                    moneyToEarn = 20.00M;
                    Console.WriteLine($"\nYou need to earn {moneyToEarn} dollers to win a Tablet");
                    PlayGame(moneyToEarn);
                    break;


            }
            Console.WriteLine($"\n\nName : {name}");
            Console.WriteLine($"Gender : {gender}");
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("Press any key to quit the game ..!");
            Console.ReadKey();
        }
        static void PlayGame(decimal amount)
        {
            var isGuessedCorrect = false;
            bool[] guessStat = new bool[5];
            Int32[] challangeValue = new Int32[5];
            var challage = 0;
            var guess = 0;
            var numberOfGuesses = 0;
            var isNumber = false;
            var totalGames = 0;
            var winGames = 0;
            var averageWiningRate = 0.0;
            var earnMoney = 0.0M;
            var rnd = new Random();
            Console.WriteLine("In this game you get 3 guesses to guess a number between 1 and 10");
            Console.WriteLine("Each right guess, you will earn $5.00 and you have to earn required money to buy the item in 5 rounds");
            while (amount != earnMoney)
            {
                if (totalGames == 5)
                {
                    break;
                }
                totalGames++;
                challage = rnd.Next(1, 11);
                challangeValue[totalGames - 1] = challage;
                Console.WriteLine($"\nRound {totalGames} :");
                isGuessedCorrect=false;
                // Console.WriteLine($"Challage : {challage}");
                numberOfGuesses = 0;
                while (numberOfGuesses < 3 || !(isGuessedCorrect))
                {
                    Console.Write($"Enter your {numberOfGuesses + 1} guess (number between 1 and 10): ");
                    isNumber = int.TryParse(Console.ReadLine(), out guess);
                    if (isNumber) // Check if the guess is a number
                    {
                        numberOfGuesses++;
                        if (guess > challage)
                        {
                            Console.WriteLine("Your guess is too high..!");
                        }
                        else if (guess < challage)
                        {
                            Console.WriteLine("Your guess is too low");
                        }
                        else
                        {
                            Console.WriteLine("Correct guess..!!");
                            earnMoney += 5.00M;
                            isGuessedCorrect = true;
                            guessStat[totalGames - 1] = true;
                            winGames++;
                            break;
                        }
                        if (numberOfGuesses == 3 && !(isGuessedCorrect))
                        {
                            Console.WriteLine("Your 3 guesses are over\n");
                            isGuessedCorrect = false;
                            guessStat[totalGames - 1] = false;

                            break;
                        }
                    }
                    else // if the guess is not a number
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("\n+-------------------------------------------------------------+");
            if (earnMoney == amount)
            {
                Console.WriteLine($"CONGRATULATIONS..!!\nYou earned $.{amount} to win the prise..");
            }
            else
            {
                Console.WriteLine($"Sorry.. You didn't earn $.{amount} to win the prise..\nTry again later..");
            }
            averageWiningRate = Math.Round((Convert.ToDouble(winGames) / totalGames), 2);
            Console.WriteLine("\nYour Result");
            Console.WriteLine($"Total: {totalGames}");
            Console.WriteLine($"Wins: {winGames}");
            Console.Write($"Your average wining rate : {averageWiningRate}\n\t");
            for (Int32 i = 0; i < totalGames; i++)
            {
                Console.Write($"\tRound{i + 1}");
            }
            Console.Write("\nChallange\t");
            for (Int32 i = 0; i < totalGames; i++)
            {
                Console.Write($"{challangeValue[i]}\t");
            }
            Console.Write("\nResult\t\t");
            for (Int32 i = 0; i < totalGames; i++)
            {
                String temp;
                if (guessStat[i]) { temp = "Correct"; } else { temp = "Missed"; }
                Console.Write($"{temp}\t");
            }

            totalGames = 0;
            winGames = 0;
        }
    }
}
