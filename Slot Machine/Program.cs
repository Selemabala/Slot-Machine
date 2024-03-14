namespace Slot_Machine;

class Program
{
    static void Main(string[] args)
    {
        const string CONTINUEPLAY = "yes";
        const int NOMONEY = 0;
        const int GRIDROWS = 3;
        const int GRIDCOLUMNS =3;
        const int FIRSTCOLUMN = 0;
        const int SECONDCOLUMN = 1;
        const int THIRDCOLOUMN = 2;
        const int FIRSTROW = 0;
        const int SECONDROW = 1;
        const int THIRDROW = 2;

        Console.WriteLine("Hello, Welcome let us play the game Slot Machine!");
        Console.WriteLine("You will be rewarded the same amount of the money that you will wage");
        Console.WriteLine("The game will automatically end once you are left with no money");
        //The starting money
      int money = 10;
        Random random = new Random();
        // 3 x 3 grid for the slot machine
        int[,] grid = new int[GRIDCOLUMNS,GRIDROWS];
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
            int loopStart = 0;
            int loopEnd = 3;
            int innerLoopStart = 0;
            int innerLoopEnd = 3;
            int gridStart = 1;
            int gridpEnd = 3;
            for (int outerloop = loopStart; outerloop < loopEnd;outerloop++)
            {
                for(int innerloop = innerLoopStart; innerloop < innerLoopEnd; innerloop++)
                {
                    //getting random numbers between 1,4
                    grid[outerloop, innerloop] = random.Next(gridStart, gridpEnd);
                }
            }
            //Outputting the grid
            Console.WriteLine("Slot Machine Grid");
            for(int outerloop = loopStart; outerloop < loopEnd; outerloop++)
            {
                for(int innerloop =innerLoopStart ; innerloop < innerLoopEnd; innerloop++)
                {
                    Console.Write(grid[outerloop, innerloop]+ " ");
                }
                Console.WriteLine();
            }
            //checking if the middle row is all the same
            if (grid[SECONDCOLUMN, FIRSTROW] == grid[SECONDCOLUMN,SECONDROW] && grid[SECONDCOLUMN, SECONDROW] == grid[SECONDCOLUMN,THIRDROW])
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
            if (money <= NOMONEY)
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

