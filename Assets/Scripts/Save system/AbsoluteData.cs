[System.Serializable]
public class AbsoluteData
{
    public bool[] collectdMapPieces;
    public int[] consumableIndexes;

    public AbsoluteData(bool[] mapMemory, int[] consumedIndexes)
    {
        collectdMapPieces = mapMemory;
        consumableIndexes = consumedIndexes;
    }
}
