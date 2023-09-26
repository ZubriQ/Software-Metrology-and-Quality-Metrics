namespace _1_Halstead_Metrics.Analysis;

public class HalsteadDictionary
{
    private readonly Random _random = new();
    
    private int _previousSpotValue = -1;
    private int _currentSpotValue = -1;

    public int Size { get; }
    public int SampleSize { get; }

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
            _currentSpotValue = _random.Next(0, Size);
            if (_currentSpotValue == _previousSpotValue)
            {
                continue;
            }
            if (array[_currentSpotValue] == 0)
            {
                remainingArraySpots--;
            }
            
            specificDictionaryGeneratedNumberCount++;
            GeneratedNumberCount++;
            array[_currentSpotValue]++;
            _previousSpotValue = _currentSpotValue;
        }
        
        return specificDictionaryGeneratedNumberCount;
    }
}