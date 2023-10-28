namespace _4_Reverse_Polish_Notation.Tests.NUnit.White_box;

internal class CombinatorialConditionCoverageTests
{
    [TestCase("", "")]
    [TestCase("1", "1")]
    [TestCase("(5)", "5")]
    [TestCase("(-5)", "5-")]
    public void When_ValidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }

    [TestCase("t / m", "incorrect data")]
    [TestCase("(", "incorrect data")]
    [TestCase("(", "incorrect data")]
    [TestCase("[9]", "incorrect data")] // Should fail.
    public void When_InvalidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }
}
