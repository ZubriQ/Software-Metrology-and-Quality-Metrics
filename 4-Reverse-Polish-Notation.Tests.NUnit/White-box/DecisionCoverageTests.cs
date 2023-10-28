namespace _4_Reverse_Polish_Notation.Tests.NUnit.White_box;

[TestFixture]
internal class DecisionCoverageTests
{
    [TestCase("5 * (5 - 5) / (5 + 5) + 1", "555-*55+/1+")]
    public void When_ValidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }

    [TestCase("a + b", "incorrect data")]
    public void When_InvalidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }
}
