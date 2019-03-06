using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    public string Name { get; private set; }
    public Stat Age { get; private set; }
    public Stat Weight { get; private set; }
    public Stat Gold { get; private set; }
    public Stat Karma { get; private set; }

    public PlayerStats()
    {
        Age = new Stat(); //TODO : INIT STAT FILE
        Weight = new Stat();
        Gold = new Stat();
    }

    public void addAge(int age)
    {
        Age.StatValue += age;
        PlayerManager.Stats.Age.StatValue = Age.StatValue;
    }
    public void minusAge(int age)
    {
        Age.StatValue -= age;
        PlayerManager.Stats.Age.StatValue = Age.StatValue;
    }
    public void addWeight(int weight)
    {
        Weight.StatValue += weight;
        PlayerManager.Stats.Weight.StatValue = Weight.StatValue;
    }
    public void minusWeight(int weight)
    {
        Weight.StatValue -= weight;
        PlayerManager.Stats.Weight.StatValue = Weight.StatValue;
    }
    public void addGold(int gold)
    {
        Gold.StatValue += gold;
        PlayerManager.Stats.Gold.StatValue = Gold.StatValue;
    }
    public void minusGold(int gold)
    {
        Gold.StatValue -= gold;
        PlayerManager.Stats.Gold.StatValue = Gold.StatValue;
    }
    public void addKarma(int karma)
    {
        Karma.StatValue += karma;
        PlayerManager.Stats.Karma.StatValue = Gold.StatValue;
    }
    public void minusKarma(int karma)
    {
        Karma.StatValue -= karma;
        PlayerManager.Stats.Karma.StatValue = Gold.StatValue;
    }

}
