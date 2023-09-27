namespace _1_Halstead_Metrics.Analysis.Models;

public record MetricData(
    double ExpectedValue,
    double Dispersion,
    double MeasurementError)
{
    public override string ToString() => $"""
         Average (M):           {Math.Round(ExpectedValue, 2)}
         Disperse (D):          {Math.Round(Dispersion, 2)}
         Measurement error (d): {MeasurementError}
         """;
}