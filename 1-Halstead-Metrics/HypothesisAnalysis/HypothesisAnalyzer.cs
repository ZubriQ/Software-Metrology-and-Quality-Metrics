using _1_Halstead_Metrics.HypothesisAnalysis.Models;

namespace _1_Halstead_Metrics.HypothesisAnalysis;

public class HypothesisAnalyzer
{
    private HypothesisTestData _testData = null!;

    public HypothesisResult Analyze(HypothesisTestData testData)
    {
        _testData = testData;
        return new HypothesisResult(GetCalculatedLength(), GetExperimentalLength());
    }
    
    /// <summary>
    /// Uses distinct element counts of operators and operands: (η1 * log2(η1) + η2 * log2(η2)).
    /// </summary>
    /// <returns>Calculated length (Ñ).</returns>
    private double GetCalculatedLength() => Math.Round(
        _testData.Operands.DistinctElementsCount * Math.Log2(_testData.Operands.DistinctElementsCount) +
        _testData.Operators.DistinctElementsCount * Math.Log2(_testData.Operators.DistinctElementsCount), 4);

    /// <summary>
    /// Sum of operators and operands appearances in code (N1 + N2).
    /// </summary>
    /// <returns>Experimental length (N).</returns>
    private int GetExperimentalLength() =>
        _testData.Operands.ElementsAppearanceCount + _testData.Operators.ElementsAppearanceCount;
}