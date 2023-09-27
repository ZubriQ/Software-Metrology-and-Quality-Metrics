using System.Text;

namespace _1_Halstead_Metrics.Analysis.Models;

public record HalsteadResult(
    MetricData StatisticalValues,
    MetricData TheoreticalValues,
    double NewExpectedSampleSize)
{
    public override string ToString()
    {
        var builder = new StringBuilder();
        
        builder.AppendLine("Statistical Values:");
        builder.AppendLine(StatisticalValues.ToString());
        builder.AppendLine("Theoretical Values:");
        builder.AppendLine(TheoreticalValues.ToString());
        builder.AppendLine($"Stable Sample Size:    {(int)NewExpectedSampleSize:N0}");
        
        return builder.ToString();
    }
}