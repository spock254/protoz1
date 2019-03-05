using System.Collections.Generic;


public class Stat
{
    public int StatValue { get; set; }
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public List<BonusStat> BonusStats { get; set; }
    private int CurrentStatValue { get; set; }


    public Stat(int statValue,string statName,string statDescription)
    {
        this.StatValue = statValue;
        this.StatName = statName;
        this.StatDescription = statDescription;
        this.BonusStats = new List<BonusStat>();
        CurrentStatValue = StatValue;
    }
    public Stat() { }

    public void AddBonus(BonusStat bonusStat)
    {
        BonusStats.Add(bonusStat);
    }
    public void RemoveBonu(BonusStat bonusStat)
    {
        BonusStats.Remove(bonusStat);
    }
    public int CalculateCurrentStatValue()
    {

        foreach (BonusStat item in BonusStats)
        {
            CurrentStatValue += item.BonusStatValue;
        }

        BonusStats.Clear(); // clear all bonus 

        return CurrentStatValue;
    }
    public void AddBonusToCurrentStateValue(BonusStat bonusStat)
    {
        CurrentStatValue += bonusStat.BonusStatValue;
    }
    
}
