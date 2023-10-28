namespace _4_Reverse_Polish_Notation.RPN;

public static class Extensions
{
    private static Stack<char> _operators = null!;
    private static List<char> _postfixExpression = null!;

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
        InitializeArrays();
        if (!IsExpressionValid(infixExpression))
        {
            return "incorrect data";
        }

        foreach (var token in infixExpression)
        {
            if (char.IsDigit(token))
            {
                _postfixExpression.Add(token);
            }
            else switch (token)
            {
                case '(':
                    _operators.Push(token);
                    break;
                case ')':
                {
                    while (_operators.Count > 0 && _operators.Peek() != '(')
                    {
                        _postfixExpression.Add(_operators.Pop());
                    }

                    if (_operators.Count > 0 && _operators.Peek() == '(')
                    {
                        // Remove an opening bracket from the stack.
                        _operators.Pop();
                    }
                    else
                    {
                        Console.WriteLine("incorrect data");
                        return null!;
                    }

                    break;
                }
                // It is an operator.
                default:
                {
                    while (_operators.Count > 0 && GetOperatorPriority(token) <= GetOperatorPriority(_operators.Peek()))
                    {
                        _postfixExpression.Add(_operators.Pop());
                    }
                    _operators.Push(token);
                    break;
                }
            }
        }

        // Add remaining operators from the stack into a postfix expression.
        while (_operators.Count > 0)
        {
            if (_operators.Peek() == '(' || _operators.Peek() == ')')
            {
                Console.WriteLine("incorrect data");
                return null!;
            }
            _postfixExpression.Add(_operators.Pop());
        }

        return new string(_postfixExpression.ToArray());
    }

    private static void InitializeArrays()
    {
        _operators = new Stack<char>();
        _postfixExpression = new List<char>();
    }

    private static bool IsExpressionValid(string expression) =>
        IsAllNumbersSingleDigit(expression) && IsNoLetterExist(expression);

    private static bool IsAllNumbersSingleDigit(string expression)
    {
        for (int i = 0; i < expression.Length - 1; i++)
        {
            if (char.IsDigit(expression[i]) && char.IsDigit(expression[i + 1]))
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsNoLetterExist(string expression) =>
        expression.All(c => !char.IsLetter(c));
}