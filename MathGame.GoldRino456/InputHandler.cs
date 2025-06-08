using System;

public class InputHandler
{
    public int PromptForInputInt()
    {
        int value = -1;

        Console.Write("Please Enter A Selection: ");
        string? input = Console.ReadLine();
        bool isValidInteger = int.TryParse(input, out value);

        if (isValidInteger)
        {
            return value;
        }
        else
        {
            return -1;
        }
    }

    public void NotifyInvalidInputInt()
    {
        Console.WriteLine("Invalid Input.");
    }
}
