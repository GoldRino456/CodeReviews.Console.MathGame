using System;

public class InputHandler
{
    public int PromptForInputInt()
    {
        int value = Int32.MinValue;

        Console.Write("Please Enter A Selection: ");
        string? input = Console.ReadLine();
        bool isValidInteger = int.TryParse(input, out value);

        if (isValidInteger)
        {
            return value;
        }
        else
        {
            return Int32.MinValue;
        }
    }

    public void NotifyInvalidInputInt()
    {
        Console.WriteLine("Invalid Input.");
    }
}
