namespace _1_Halstead_Metrics.HypothesisAnalysis.Models;

public record HypothesisResult(double CalculatedLength, int ExperimentalLength)
{
    public override string ToString() => $"""
                                          Calculated length (Ñ):    {CalculatedLength}
                                          Experimental length (N):  {ExperimentalLength}
                                          """;
}