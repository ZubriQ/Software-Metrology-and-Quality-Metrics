namespace _1_Halstead_Metrics.Analysis;

public record HalsteadResult(
    MetricData StatisticalValues,
    MetricData TheoreticalValues,
    double NewExpectedSampleSize);