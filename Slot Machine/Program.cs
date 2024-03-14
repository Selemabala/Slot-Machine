namespace Slot_Machine;

class Program
{
    static void Main(string[] args)
    {
        const string CONTINUEPLAY = "yes";

        Console.WriteLine("Hello, Welcome let us play the game Slot Machine!");
        Console.WriteLine("You will be rewarded the same amount of the money that you will wage");
        Console.WriteLine("The game will automatically end once you are left with no money");
        //The starting money
      int money = 10;
        Random random = new Random();
        // 3 x 3 grid for the slot machine
        int[,] grid = new int[3,3];
        // creating an infinite loop to only to be stoped after the user types exit
        while (true)
        {
            Console.WriteLine($"\nYou have {money} as the amount of money) how much would you like to wager?");
            int wager = Convert.ToInt32(Console.ReadLine());
            if (wager > money)
            {
                Console.WriteLine("You dont have enough money to wager");
                continue;
            }
            //deducting money from the wager
            money = money - wager; //(I could also use money-=wager)

            //filling the grid with random numbers
            for (int outerloop = 0; outerloop < 3;outerloop++)
            {
                for(int innerloop = 0; innerloop < 3; innerloop++)
                {
                    //getting random numbers between 1,4
                    grid[outerloop, innerloop] = random.Next(1, 4);
                }
            }
            //Outputting the grid
            Console.WriteLine("Slot Machine Grid");
            for(int outerloop = 0; outerloop < 3; outerloop++)
            {
                for(int innerloop = 0; innerloop < 3; innerloop++)
                {
                    Console.Write(grid[outerloop, innerloop]+ " ");
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

            //quitting the game if the money is o
            if (money <= 0)
            {
                break;
            }

            //asking if the user wants to play more
            Console.WriteLine("Do you want to play again?");
            Console.WriteLine("Please type yes if you want to play and no if you dont want to play");
            string userchoice = Console.ReadLine();
            if (userchoice.ToLower() == CONTINUEPLAY)
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

