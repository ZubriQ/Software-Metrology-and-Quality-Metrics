namespace _4_Reverse_Polish_Notation.Tests.NUnit.White_box;

internal class ConditionCoverageTests
{
    [TestCase("5 + (6 / 3 * 2) - 7", "563/2*+7-")]
    public void When_ValidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }

    [TestCase("33 + (40 / 20)", "incorrect data")]
    public void When_InvalidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }
}