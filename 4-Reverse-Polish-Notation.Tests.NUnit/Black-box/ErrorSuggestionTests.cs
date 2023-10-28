namespace _4_Reverse_Polish_Notation.Tests.NUnit.Black_box;

[TestFixture]
internal class ErrorSuggestionTests
{
    // Should generate a failed test.
    [TestCase("1 - [5 + 3]", "incorrect data")]
    public void When_InvalidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }
}