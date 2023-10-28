namespace _4_Reverse_Polish_Notation.RPN;

public static class Extensions
{
    public static string ToPostfix(this string inputConverter) => 
        ConvertToPostfix(inputConverter.Replace(" ", ""));

    private static int GetOperatorPriority(char op) => op switch
    {
        '(' => 0,
        ')' => 1,
        '+' or '-' => 2,
        '*' or '/' => 3,
        _ => -1,
    };

    private static string ConvertToPostfix(string infixExpression)
    {
        var operators = new Stack<char>();
        var postfixExpression = new List<char>();

        foreach (var token in infixExpression)
        {
            if (char.IsDigit(token))
            {
                postfixExpression.Add(token);
            }
            else switch (token)
            {
                case '(':
                    operators.Push(token);
                    break;
                case ')':
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

                    break;
                }
                // It is an operator.
                default:
                {
                    while (operators.Count > 0 && GetOperatorPriority(token) <= GetOperatorPriority(operators.Peek()))
                    {
                        postfixExpression.Add(operators.Pop());
                    }
                    operators.Push(token);
                    break;
                }
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