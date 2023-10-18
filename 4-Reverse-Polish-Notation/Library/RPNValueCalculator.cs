namespace _4_Reverse_Polish_Notation.Library;

public static class RPNValueCalculator
{
    public static void CalculateInput()
    {
        char[] sp = new char[] { ' ', '\t' };
        for (;;)
        {
            string s = Console.ReadLine()!;
            if (s == null) break;

            Stack<string> tks = new Stack<string>(s.Split(sp, StringSplitOptions.RemoveEmptyEntries));

            if (tks.Count == 0) continue;

            try
            {
                double r = EvaluateTokens(tks);
                if (tks.Count != 0)
                {
                    throw new Exception();
                }
                Console.WriteLine(r);
            }
            catch (Exception) 
            { 
                Console.WriteLine("Error");
            }

            Console.ReadLine();
        }
    }

    private static double EvaluateTokens(Stack<string> tks)
    {
        string tk = tks.Pop();
        double x, y;
        if (!double.TryParse(tk, out x))
        {
            y = EvaluateTokens(tks); 
            x = EvaluateTokens(tks);
            if (tk == "+") 
                x += y;
            else if (tk == "-") 
                x -= y;
            else if (tk == "*") 
                x *= y;
            else if (tk == "/") 
                x /= y;
            else 
                throw new Exception();
        }
        return x;
    }
}