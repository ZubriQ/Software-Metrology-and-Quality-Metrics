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
    [TestCase("c + b * a", "incorrect data")]
    [TestCase("77 + 99 - 10", "incorrect data")]
    public void When_InvalidInput(string infixExpression, string expectedPostfixExpression)
    {
        Tester.TestToPostfixExpression(infixExpression, expectedPostfixExpression);
    }
}