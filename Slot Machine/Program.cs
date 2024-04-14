using System;
using System.Collections.Generic;
using System.Drawing;

namespace Slot_Machine;

class Program
{
    static void Main(string[] args)
    {
        const string CONTINUE_PLAY = "yes";
        const int NO_MONEY_LEFT = 0;
        const int GRID_ROWS = 3;
        const int GRID_COLUMNS = 3;
        const int LOOP_START = 0;
        const int LOOP_END = 3;
        const int GRID_START = 1;
        const int GRID_END = 4;
        const int FIRST_GRID_VALUE = 0;
        const int MIDDLE_LINE = 1;
        const int ALL_HORIZONTALS = 2;
        const int ALL_VERTICALS = 3;
        const int BOTH_DIAGNALS = 4;
        const int EVERYTHING_ON_THE_GRID = 5;
        const int INITIAL_MONEY = 10;

        Console.WriteLine("Hello, Welcome let us play the game Slot Machine!");
        Console.WriteLine("You will be rewarded the same amount of the money that you will wage");
        Console.WriteLine("The game will automatically end once you are left with no money");
        //The starting money

        Random random = new Random();
        // 3 x 3 grid for the slot machine
        int[,] grid = new int[GRID_COLUMNS, GRID_ROWS];

        int choice;
        int wager;
        int money = INITIAL_MONEY;

        // creating an infinite loop to only to be stoped after the user types exit
        while (true)
        {
            while (true)
            {
                //giving the user an option to choose what to play

                Console.WriteLine("Choose where do you want to play");
                Console.WriteLine($"Press {MIDDLE_LINE}  for the middle line, {ALL_HORIZONTALS} for all horizontals,  {ALL_VERTICALS} for all verticals,  {BOTH_DIAGNALS} for both diagnals,  and  {EVERYTHING_ON_THE_GRID} for everything in the grid");

                string userInPut = Console.ReadLine();

                bool success = int.TryParse(userInPut, out choice);
                if (success && choice >= MIDDLE_LINE && choice <= EVERYTHING_ON_THE_GRID)

                {
                    break;
                }

                Console.WriteLine("Please enter a valid number");
            }

            Console.WriteLine($"\nYou have {money} as the amount of money, how much would you like to wager? type amount and press enter");
            while (true)
            {
                string moneyFromUser = Console.ReadLine();

                bool correctAmount = int.TryParse(moneyFromUser, out wager);
                if (correctAmount && wager > NO_MONEY_LEFT && wager <= money)
                {

                    break;
                }

                if (wager > money)
                {
                    Console.WriteLine("You dont have enough money to wager");
                    continue;
                }
   
                    Console.WriteLine("enter a valid amount of money to wager");            
            }

            //deducting money from the wager
            money -= wager; //(I could also use money-=wager)

            //filling the grid with random numbers
            int outerloop = 0;
            for (outerloop = LOOP_START; outerloop < LOOP_END; outerloop++)
            {
                for (int insideloop = LOOP_START; insideloop < LOOP_END; insideloop++)
                {
                    //getting random numbers between 1,4
                    grid[outerloop, insideloop] = random.Next(GRID_START, GRID_END);
                }
            }
            //Outputting the grid
            Console.WriteLine("Slot Machine Grid");

            for (outerloop = LOOP_START; outerloop < LOOP_END; outerloop++)
            {
                for (int inside = LOOP_START; inside < LOOP_END; inside++)
                {
                    Console.Write(grid[outerloop, inside] + " ");
                }
                Console.WriteLine();
            }

            //checking if the middle line values are all the same
            int gridRowLength = grid.GetLength(0);
            int gridColumnLength = grid.GetLength(1);
            bool isWin = false;
            int winningLine = MIDDLE_LINE;
            if (choice == MIDDLE_LINE)
            {
                for (outerloop = FIRST_GRID_VALUE; outerloop < gridRowLength; outerloop++)
                {
                    int holizontalMatch = 0;

                    int horizontalValue = grid[outerloop, FIRST_GRID_VALUE];

                    for (int innerloop = FIRST_GRID_VALUE; innerloop < gridColumnLength; innerloop++)
                    {
                        if (horizontalValue == grid[outerloop, innerloop])

                        {
                            holizontalMatch++;
                        }
                    }

                    if (holizontalMatch == gridRowLength && outerloop == winningLine)

                    {
                        isWin = true;
                    }
                }

                if (isWin)
                {
                    Console.WriteLine($"Conglatulation you won");
                    //adding wager amount to the total money
                    money = money + wager;
                }
                else
                {
                    Console.WriteLine("Sorry you did not win");
                }

            }

            //checking if the  horinzontal are all the same
            bool rowWin = true;
            if (choice == ALL_HORIZONTALS)
            {
                for (outerloop = FIRST_GRID_VALUE; outerloop < gridRowLength; outerloop++)
                {
                    int horizontalValue = grid[outerloop, FIRST_GRID_VALUE];

                    for (int innerloop = FIRST_GRID_VALUE; innerloop < gridColumnLength; innerloop++)
                    {
                        if (horizontalValue != grid[outerloop, innerloop])

                        {
                            rowWin = false;
                            break;
                        }

                    }

                    if (!rowWin)

                    {
                        break;
                    }
                }

                if (rowWin)

                {
                    Console.WriteLine($"Conglatulation you won");
                    //adding wager amount to the total money
                    money = money + wager;
                }

                else
                {
                    Console.WriteLine("Sorry you did not win");
                }
            }

            //checking if the Vertical are all the same

            bool verticalWin = true;

            if (choice == ALL_VERTICALS)
            {
                for (outerloop = FIRST_GRID_VALUE; outerloop < gridRowLength; outerloop++)
                {
                    int verticalValue = grid[FIRST_GRID_VALUE, outerloop];

                    for (int innerloop = FIRST_GRID_VALUE; innerloop < gridColumnLength; innerloop++)
                    {
                        if (verticalValue != grid[innerloop, outerloop])

                        {
                            verticalWin = false;
                            break;
                        }
                    }

                    if (!verticalWin)

                    {
                        break;
                    }
                }

                if (verticalWin)

                {
                    Console.WriteLine($"Conglatulation you won");
                    //adding wager amount to the total money
                    money = money + wager;
                }

                else
                {
                    Console.WriteLine("Sorry you did not win");
                }

            }

            //checking if the diagnal are all the same
            int diagnolValues = grid[FIRST_GRID_VALUE, FIRST_GRID_VALUE];
            bool secondDiagnalMatch = true;
            bool diagnalMatch = true;
            int actualGridRowLenght = gridRowLength - GRID_START;
            int secondDiagnalValues = grid[FIRST_GRID_VALUE, gridRowLength - GRID_START];
            if (choice == BOTH_DIAGNALS)
            {
                for (outerloop = FIRST_GRID_VALUE; outerloop < gridRowLength; outerloop++)
                {
                    for (int innerloop = FIRST_GRID_VALUE; innerloop < gridColumnLength; innerloop++)
                    {
                        if (diagnolValues != grid[innerloop, innerloop])
                        {
                            diagnalMatch = false;
                            break;
                        }
                        if (secondDiagnalValues != grid[outerloop, actualGridRowLenght - outerloop])
                        {
                            secondDiagnalMatch = false;
                            break;
                        }
                    }
                }

                if (diagnalMatch && secondDiagnalMatch)
                {
                    Console.WriteLine($"Conglatulation you won");
                    //adding wager amount to the total money
                    money = money + wager;
                }
                else
                {
                    Console.WriteLine("Sorry you did not win");
                }
            }

            bool horizontalWinInEverything = true;
            bool verticalWinInEverything = true;
            if (choice == EVERYTHING_ON_THE_GRID)
            {
                for (outerloop = FIRST_GRID_VALUE; outerloop < gridRowLength; outerloop++)
                {
                    int horizontalValue = grid[outerloop, FIRST_GRID_VALUE];
                    int verticalValue = grid[FIRST_GRID_VALUE, outerloop];

                    for (int innerloop = FIRST_GRID_VALUE; innerloop < gridColumnLength; innerloop++)
                    {
                        if (verticalValue != grid[innerloop, outerloop])
                        {
                            verticalWinInEverything = false;
                            break;
                        }

                        if (horizontalValue != grid[outerloop, innerloop])
                        {
                            horizontalWinInEverything = false;
                            break;
                        }
                    }

                    if (!verticalWinInEverything || !horizontalWinInEverything)

                    {
                        break;
                    }
                }

                if (verticalWinInEverything && horizontalWinInEverything)

                {
                    Console.WriteLine($"Conglatulation you won");
                    //adding wager amount to the total money
                    money = money + wager;
                }

                else
                {
                    Console.WriteLine("Sorry you did not win");
                }

            }

            //informing the total amount of money
            Console.WriteLine($"Currently, your total money is {money}");

            //quitting the game if the money is o
            if (money <= NO_MONEY_LEFT)
            {
                Console.Write("Your money now is 0, the game ends here");
                break;
            }
            //asking if the user wants to play more
            Console.WriteLine("Do you want to play again?");
            Console.WriteLine("Please type yes if you want to play and no if you dont want to play");
            string userchoice = Console.ReadLine();
            if (userchoice.ToLower() == CONTINUE_PLAY)
            {
                Console.WriteLine("Alright, lets keep going");
            }
            //exiting the loop game if the answer is not yes
            else
            {
                Console.Write("The game ends here");
                Console.WriteLine("Thank you so much for playing");
                break;
            }
        }
    }
}