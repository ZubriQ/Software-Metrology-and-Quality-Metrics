using _4_Reverse_Polish_Notation.RPN;

namespace _4_Reverse_Polish_Notation;

internal static class Program
{
    private static void Main()
    {
        const string infixExpression = "3 + 4 * (2 - 1)";
        var postfixExpression = infixExpression.ToPostfix();
        Console.WriteLine("Postfix: " + postfixExpression);

        Console.ReadLine();
    }
}