namespace _4_Reverse_Polish_Notation.Tests.NUnit.White_box;

[TestFixture]
internal class StatementCoverageTests
{
    [TestCase("3 * (5 - 1) / (4 + 4)", "351-*44+/")]
    [TestCase("(5 + (6 / 2)) - (2 * 8)", "562/+28*-")]
    public void When_ValidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }
}