namespace _4_Reverse_Polish_Notation.Tests.NUnit.Black_box;

[TestFixture]
internal class EquivalencePartitioningTests
{
    [TestCase("3 + 4 * (2 - 1)", "3421-*+")]
    [TestCase("(2 + 9 / (7 - 1))", "2971-/+")]
    [TestCase("3 + 4 * 2", "342*+")]
    
    public void When_ValidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }

    [TestCase("(2 + 11 / (7 - 1))", "incorrect data")]
    [TestCase("3 + 4 * a", "incorrect data")]
    [TestCase("8 + 99 - 1", "incorrect data")]
    public void When_InvalidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }
}