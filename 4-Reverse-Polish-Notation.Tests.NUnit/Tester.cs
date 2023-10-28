using _4_Reverse_Polish_Notation.RPN;

namespace _4_Reverse_Polish_Notation.Tests.NUnit;

internal static class Tester
{
    public static void TestToPostfixExpression(string infixExpression, string expectedPostfixExpression)
    {
        // Act
        var postfixExpression = infixExpression.ToPostfix();
        // Assert
        Assert.That(expectedPostfixExpression, Is.EqualTo(postfixExpression));
    }
}