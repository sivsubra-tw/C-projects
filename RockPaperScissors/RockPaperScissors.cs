namespace Game;

public enum Input
{
    ROCK = 0,
    PAPER,
    SCISSORS
}
public class RockPaperScissors
{
    public void Play()
    {
        Console.WriteLine("Rock-Paper-Scissors: Best of 5 rounds");

        bool enterInput = true;
        Input userChoice = Input.ROCK;
        int round = 1;
        int userScore = 0;
        int computerScore = 0;

        while (round <= 5)
        {
            Console.WriteLine($"Round #{round}\n");
            Console.WriteLine($"Your score: {userScore}");
            Console.WriteLine($"Computer: {computerScore}\n");

            EnterChoice:
            Console.WriteLine($"1 - {Input.ROCK}");
            Console.WriteLine($"2 - {Input.PAPER}");
            Console.WriteLine($"3 - {Input.SCISSORS}");
            Console.Write("Enter your choice between 1 and 3: ");

            string userInput = Console.ReadLine();

            try
            {
                userChoice = (Input)(Int32.Parse(userInput) - 1);
                enterInput = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input!");
                goto EnterChoice;
            }

            Input computerChoice = ComputerTurn();

            Input winner = DeclareWinner(userChoice, computerChoice);
            Input loser = (userChoice == winner) ? computerChoice : userChoice;

            Console.WriteLine($"{winner} beats {loser}");

            if (userChoice == winner) userScore++; else computerScore++;
            
            Console.WriteLine("--------------------------");
            round++;
        }

        Console.WriteLine("FINAL SCORES");
        Console.WriteLine($"You - Computer : {userScore} - {computerScore}\n");

        if(userScore > computerScore)
            Console.WriteLine("You win!");
        else if (userScore < computerScore)
            Console.WriteLine("Better luck next time!");
        else
            Console.WriteLine("It's a draw!");
    }
    public Input ComputerTurn()
    {
        Random rnd = new Random();
        int choice = rnd.Next(0, 3);
        Console.WriteLine($"Computer chose {(Input)choice}");
        return (Input)choice;
    }
    public Input DeclareWinner(Input input1, Input input2)
    {
        switch (input1)
        {
            case Input.ROCK:
                return (input2 == Input.PAPER) ? Input.PAPER : Input.ROCK;
            case Input.SCISSORS:
                return (input2 == Input.ROCK) ? Input.ROCK : Input.SCISSORS;
            case Input.PAPER:
                return (input2 == Input.SCISSORS) ? Input.SCISSORS : Input.PAPER;

            default:
                throw new ArgumentException("Not a valid input");
                break;
        }
    }
}