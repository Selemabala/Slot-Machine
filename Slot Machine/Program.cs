namespace Slot_Machine;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Welcome to play this Slot Machine game!");
        //The starting money
        int money = 10;
        Random random = new Random();
        // 3 x 3 grid for the slot machine
        int[,] grid = new int[3,3];
        // creating an infinite loop to only to be stoped after the user types exit
        for (;;)
        {
            Console.WriteLine($"\nYou have {money} as the amount of money, how much would you like to wager?");
            int wager = Convert.ToInt32(Console.ReadLine());
            if (wager > money)
            {
                Console.WriteLine("You dont have enough money to wager");
                continue;
            }
            //deducting money from the wager
            money = money - wager; //(I could also use money-=wager)

            //filling the grid with random numbers
            for (int i = 0; i < 3;i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    //getting random numbers between 1,4
                    grid[i, j] = random.Next(1, 4);
                }
            }
            //Outputting the grid
            Console.WriteLine("Slot Machine Grid");
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; i < 3; j++)
                {
                    Console.Write(grid[i, j]+ " ");
                }
                Console.WriteLine();
            }
            //checking if the middle row is all the same
            if (grid[1, 0] == grid[1,1] && grid[1, 1] == grid[1,2])
            {
                Console.WriteLine("Conglatualations, you won");
                //adding wager amount to the total money
                money = money + wager;
            }
            else
            {
                Console.WriteLine("Sorry, you are a loser");
            }
            //informing the total amount of money
            Console.WriteLine($"Currently, your total money is {money}");

            //asking if the user wants to play more
            Console.WriteLine("Do you want to play again?)");
            Console.WriteLine("Please type yes if you want to play and no if you dont want to play");
            string continueAnswer = "yes";
            string userchoice = Console.ReadLine();
            if (userchoice.ToLower() == continueAnswer)
            {
                continue;
            }
            //exiting the loop game if the answer is not yes
            else
            {
                break;
            }
                
        }
        Console.WriteLine("Thank you so much for playing");
    }
}

