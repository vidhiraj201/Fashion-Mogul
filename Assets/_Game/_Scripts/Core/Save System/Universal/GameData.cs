[System.Serializable]
public class GameData 
{
    public int totalMoney;
    public int DayCount;
    public int totalEmployeeCount;
    public bool isTutorialOver, isFinalTutorialOver, do1, do2, do3;

    public GameData()
    {
        totalMoney = 0;
        DayCount = 0;
        totalEmployeeCount = 0;
        isTutorialOver = false;
        isFinalTutorialOver = false;
        do1 = false;
        do2 = false;
        do3 = false;

    }
}
