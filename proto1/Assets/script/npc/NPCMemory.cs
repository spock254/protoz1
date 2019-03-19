using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMemory : MonoBehaviour
{
   // [SerializeField]
    private Dictionary<string, bool> questMemory;
    // Start is called before the first frame update
    void Start()
    {
        questMemory = new Dictionary<string, bool>();
    }

    public void AddQuestMemory(BaseQuest quest)
    {
        questMemory.Add(quest.Name, quest.isQuestPass);
    }
}
