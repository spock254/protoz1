using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = new PlayerStats();
        stats.Age.StatDescription = "Player Age";
        stats.Age.StatName = "Age";
        stats.Age.StatValue = 18;

        //TODO копирывание по значению не по ссылке
        PlayerManager.Stats.Age = new Stat();
        PlayerManager.Stats.Age.StatValue = 55;

        AnimationAgeSet.AgeSwitcher();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
