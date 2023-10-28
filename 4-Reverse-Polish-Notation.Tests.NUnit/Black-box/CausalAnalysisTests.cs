namespace _4_Reverse_Polish_Notation.Tests.NUnit.Black_box;

[TestFixture]
internal class CausalAnalysisTests
{
    [TestCase("0 - 7", "07-")]
    public void When_ValidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }

    [TestCase("0 - 70", "incorrect data")]
    [TestCase("10 * 7", "incorrect data")]
    [TestCase("10 * 70", "incorrect data")]
    public void When_InvalidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }
}