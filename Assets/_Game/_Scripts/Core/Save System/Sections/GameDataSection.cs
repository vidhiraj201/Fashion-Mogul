[System.Serializable]
public class GameDataSection 
{
    public int Section_1;
    public int Section_2;
    public int Section_3;

    public bool Section_1_Cam;
    public bool Section_2_Cam;
    public bool Section_3_Cam;
    public GameDataSection()
    {
        Section_1 = 1500;
        Section_2 = 2500;
        Section_3 = 5000;

        Section_1_Cam = false;
        Section_2_Cam = false;
        Section_3_Cam = false;
    }
}
