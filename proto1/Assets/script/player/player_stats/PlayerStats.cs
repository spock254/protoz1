using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    public string Name { get; set; }
    public Stat Age { get; set; }
    public Stat Weight { get; set; }
    public Stat Gold { get; set; }

    public PlayerStats()
    {
        Age = new Stat();
        Weight = new Stat();
        Gold = new Stat();
    }
}
