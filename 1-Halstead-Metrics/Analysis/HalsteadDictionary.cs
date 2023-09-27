namespace _1_Halstead_Metrics.Analysis;

public class HalsteadDictionary
{
    private static readonly Random Random = new();
    
    public int Size { get; }
    public int SampleSize { get; }

    public long GeneratedNumberCount { get; private set; }
    
    public HalsteadDictionary(int dictionarySize, int sampleSize)
    {
        Size = dictionarySize;
        SampleSize = sampleSize;
    }
    
    public long GenerateDictionaryLength()
    {
        long specificDictionaryGeneratedNumberCount = 0;
        var remainingArraySpots = Size;
        var array = new int[Size];
        var previousSpotValue = -1;
        
        while (remainingArraySpots > 0)
        {
            var currentSpotValue = Random.Next(0, Size);
            if (currentSpotValue == previousSpotValue) continue;
            
            if (array[currentSpotValue] == 0)
            {
                remainingArraySpots--;
            }
            
            specificDictionaryGeneratedNumberCount++;
            GeneratedNumberCount++;
            array[currentSpotValue]++;
            previousSpotValue = currentSpotValue;
        }
        
        return specificDictionaryGeneratedNumberCount;
    }
}
