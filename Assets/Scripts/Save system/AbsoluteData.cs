[System.Serializable]
public class AbsoluteData
{
    public bool[] collectdMapPieces;
    public bool[] markedZones;
    public float[] fvalValues;
    public int[] consumableIndexes;

    public AbsoluteData(bool[] mapMemory, bool[] markedZones, int[] consumedIndexes, float[] fvalValues)
    {
        this.markedZones = markedZones;
        collectdMapPieces = mapMemory;
        consumableIndexes = consumedIndexes;
        this.fvalValues = fvalValues;
    }
}
