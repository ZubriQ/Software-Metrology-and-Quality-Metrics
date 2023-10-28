namespace _4_Reverse_Polish_Notation.Tests.NUnit.Black_box;

[TestFixture]
internal class BoundaryValuesTests
{
    [TestCase("0 + 0 + 0", "00+0+")]
    [TestCase("0 / 0", "00/")]
    public void When_ValidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }

    [TestCase($"2147483647 + 5", "incorrect data")]
    [TestCase($"-2147483648 + 3", "incorrect data")]
    [TestCase($"2147483648 + 5", "incorrect data")]
    [TestCase($"-2147483649 + 3", "incorrect data")]

    public void When_InvalidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }
}
