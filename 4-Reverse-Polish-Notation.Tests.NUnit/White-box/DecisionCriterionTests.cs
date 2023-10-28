namespace _4_Reverse_Polish_Notation.Tests.NUnit.White_box;

[TestFixture]
internal class DecisionCriterionTests
{
    [TestCase("(5 + 5) / 5 * 1 - 5", "55+5/1*5-")]
    [TestCase("5 + 0", "50+")]
    public void When_ValidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }

    [TestCase("33 + (40 / 20)", "incorrect data")]
    [TestCase("a + (b / c)", "incorrect data")]
    [TestCase("{2 + 3}", "incorrect data")] // Should fail the test with {} characters
    public void When_InvalidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }
}