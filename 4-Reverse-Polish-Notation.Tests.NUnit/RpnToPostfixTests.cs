using _4_Reverse_Polish_Notation.RPN;

namespace _4_Reverse_Polish_Notation.Tests.NUnit;

public class RpnToPostfixTests
{
    [TestCase("3 + 4 * (2 - 1)", "3421-*+")]
    [TestCase("(2 + 9 / (7 - 1))", "2971-/+")]
    [TestCase("(2 + 11 / (7 - 1))", "incorrect data")]
    [TestCase("3 + 4 * 2", "342*+")]
    [TestCase("3 + 4 * a", "incorrect data")]
    public void TestToPostfix(string infixExpression, string expectedPostfixExpression)
    {
        // Act
        var postfixExpression = infixExpression.ToPostfix();

        // Assert
        Assert.That(expectedPostfixExpression, Is.EqualTo(postfixExpression));
    }
}