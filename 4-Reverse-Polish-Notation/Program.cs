using _4_Reverse_Polish_Notation.Library;

namespace _4_Reverse_Polish_Notation;

internal class Program
{
    static void Main()
    {
        while (true)
        {
            string infixExpression = "3 + 4 * (2 - 1)";
            string postfixExpression = infixExpression.ToPostfix();
            if (postfixExpression != null)
            {
                Console.WriteLine("Postfix: " + postfixExpression);
            }

            Console.ReadLine();
        }
    }
}