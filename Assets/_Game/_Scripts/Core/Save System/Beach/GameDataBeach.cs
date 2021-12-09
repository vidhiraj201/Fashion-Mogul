[System.Serializable]
public class GameDataBeach
{
    public bool unlock1;
    public bool unlock2;
    public bool unlock3;
    public bool unlock4;

    public bool S1;
    public bool S2;
    public bool S3;
    public bool S4;

    public int empCount;

    public GameDataBeach()
    {
        empCount = 0;

        unlock1 = false;
        unlock2 = false;
        unlock3 = false;
        unlock4 = false;

        S1 = false;
        S2 = false;
        S3 = false;
        S4 = false;
    }
}
