namespace _1_Halstead_Metrics.Analysis;

public class HalsteadDictionary
{
    private readonly Random _random = new();
    
    public int Size { get; }
    public int SampleSize { get; }
    
    private int PreviousSpotValue { get; set; } = -1;
    private int CurrentSpotValue { get; set; } = -1;
    public long GeneratedNumberCount { get; private set; }
    
    public HalsteadDictionary(int dictionarySize, int sampleSize)
    {
        Size = dictionarySize;
        SampleSize = sampleSize;
    }
    
    public long GenerateSpecificDictionaryLength()
    {
        long specificDictionaryGeneratedNumberCount = 0;
        var remainingArraySpots = Size;
        var array = new int[Size];
        
        while (remainingArraySpots > 0)
        {
            CurrentSpotValue = _random.Next(0, Size);
            if (CurrentSpotValue == PreviousSpotValue)
            {
                continue;
            }
            if (array[CurrentSpotValue] == 0)
            {
                remainingArraySpots--;
            }
            
            specificDictionaryGeneratedNumberCount++;
            GeneratedNumberCount++;
            array[CurrentSpotValue]++;
            PreviousSpotValue = CurrentSpotValue;
        }
        
        return specificDictionaryGeneratedNumberCount;
    }
}