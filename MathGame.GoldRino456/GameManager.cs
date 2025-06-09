using System.Data;

public class GameManager
{
    //1- Addition (+) 2- Subtraction (-) 3- Multiplication (*) 4- Division (/) 5- Random! (?)
    private Dictionary<int, string> _gameTypes = new Dictionary<int, string> { { 1, "+" }, { 2, "-" }, { 3, "*" }, { 4, "/" } };
    private Random _randomNumberGenerator = new();
    private int _gameType = -1;
    private int _currentScore;
    private const int _maxRandomInt = 11;
    private string _nextMathProblem = "";


    public GameHistoryEntry StartGame(int gameType, InputHandler inputHandler)
    {
        _gameType = gameType;
        _currentScore = 0;
        var symbolToUse = _gameType;

        while(true)
        {
            //Refresh Screen
            Console.Clear();

            //Roll Next Problem
            if(_gameType == 5)
            {
                symbolToUse = RollRandomSymbol();
            }
            _nextMathProblem = RollRandomProblem(symbolToUse);
            
            //Get And Check User Answer (Correct - Continue. Incorrect - Return to Menu.)
            if(ProcessMathProblem(inputHandler))
            {
                _currentScore++;
                Console.WriteLine("Correct! Press Enter For Next Problem...");
                Console.ReadLine();
                continue;
            }
            else
            {
                GameHistoryEntry newEntry = new(_gameType, _currentScore);

                Console.WriteLine("Incorrect Answer! Game Over!");
                Console.WriteLine($"Final Score: {_currentScore}");
                Console.Write("Press Enter To Return To Menu...");
                Console.ReadLine();
                return newEntry;
            }
            
        }
    }

    private string RollRandomProblem(int gameType)
    {
        string symbol = _gameTypes[gameType];
        string problem;

        var num1 = _randomNumberGenerator.Next(_maxRandomInt);
        var num2 = _randomNumberGenerator.Next(_maxRandomInt);

        if(symbol.Equals("/"))
        {
            var num3 = num1 * num2;
            if(num3 == 0) { num1 = _randomNumberGenerator.Next(1, _maxRandomInt); } //Prevent Divide By Zero and 0/0 (NaN)

            problem = $"{num3} {symbol} {num1}";
        }
        else
        {
            problem = $"{num1} {symbol} {num2}";
        }
        
        return problem;
    }

    private int RollRandomSymbol()
    {
        return _randomNumberGenerator.Next(1, 5);
    }

    private bool ProcessMathProblem(InputHandler inputHandler)
    {
        Console.WriteLine($"Solve The Equation: {_nextMathProblem}");

        var rawResult = new DataTable().Compute(_nextMathProblem, null);
        int solution = Convert.ToInt32(rawResult);

        int input = Int32.MinValue;
        while(input == Int32.MinValue)
        {
            input = inputHandler.PromptForInputInt();
        }

        return solution == input;
    }
}
