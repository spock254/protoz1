using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = new PlayerStats();
        playerStats.Age = new Stat(17, "Age", "your Age");
        playerStats.Gold = new Stat(324, "Gold", "your Gold");
        playerStats.Name = "Roor";
        playerStats.Weight = new Stat(40, "Weight", "your Weight");

        PlayerManager.Stats.Age = playerStats.Age;
        PlayerManager.Stats.Name = playerStats.Name;
        PlayerManager.Stats.Weight = playerStats.Weight;
        PlayerManager.Stats.Gold = playerStats.Gold;
 
    }

    // Update is called once per frame
    void Update()
    {

    }
}
