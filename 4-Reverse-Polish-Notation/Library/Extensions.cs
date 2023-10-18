namespace _4_Reverse_Polish_Notation.Library;

internal static class Extensions
{
    public static string ToPostfix(this string inputConverter) => ConvertToPostfix(inputConverter.Replace(" ", ""));

    static int GetOperatorPriority(char op) => op switch
    {
        '(' => 0,
        ')' => 1,
        '+' or '-' => 2,
        '*' or '/' => 3,
        _ => -1,
    };

    static string ConvertToPostfix(string infixExpression)
    {
        Stack<char> operators = new Stack<char>();
        List<char> postfixExpression = new List<char>();

        foreach (char token in infixExpression)
        {
            if (char.IsDigit(token))
            {
                postfixExpression.Add(token);
            }
            else if (token == '(')
            {
                operators.Push(token);
            }
            else if (token == ')')
            {
                while (operators.Count > 0 && operators.Peek() != '(')
                {
                    postfixExpression.Add(operators.Pop());
                }

                if (operators.Count > 0 && operators.Peek() == '(')
                {
                    // Remove an opening bracket from the stack.
                    operators.Pop();
                }
                else
                {
                    Console.WriteLine("Error: Inconsistent parentheses in an expression.");
                    return null!;
                }
            }
            else // It is an operator.
            {
                while (operators.Count > 0 && GetOperatorPriority(token) <= GetOperatorPriority(operators.Peek()))
                {
                    postfixExpression.Add(operators.Pop());
                }
                operators.Push(token);
            }
        }

        // Add remaining operators from the stack into a postfix expression.
        while (operators.Count > 0)
        {
            if (operators.Peek() == '(' || operators.Peek() == ')')
            {
                Console.WriteLine("Error: Inconsistent parentheses in an expression.");
                return null!;
            }
            postfixExpression.Add(operators.Pop());
        }

        return new string(postfixExpression.ToArray());
    }
}
