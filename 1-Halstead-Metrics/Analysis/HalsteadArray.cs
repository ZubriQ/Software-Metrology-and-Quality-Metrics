namespace _1_Halstead_Metrics.Analysis;

public class HalsteadArray
{
    public int Size { get; private set; }
    public int SampleSize { get; private set; }
    
    public int PreviousSpotValue { get; set; } = -1;
    public int CurrentSpotValue { get; set; } = -1;
    public ulong GeneratedNumberCount { get; set; }
    
    public HalsteadArray(int dictionarySize, int sampleSize)
    {
        Size = dictionarySize;
        SampleSize = sampleSize;
    }
}