namespace _4_Reverse_Polish_Notation.Tests.NUnit.White_box;

[TestFixture]
internal class ConditionCoverageTests
{
    [TestCase("5 + (6 / 3 * 2) - 7", "563/2*+7-")]
    public void When_ValidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }

    [TestCase("33 + (40 / 20)", "incorrect data")]
    [TestCase("33 + (b / c)", "incorrect data")]
    [TestCase("1 + [5 / 5]", "incorrect data")] // Should fail the test with [] characters
    public void When_InvalidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }
}