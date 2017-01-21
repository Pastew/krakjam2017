using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvent : MonoBehaviour {

    public string description;
    public List<string> affectedCities;
    public int effect;
    public List<int> auditions;
    public DateTime dateTime;

    Diary diary;

    public GameEvent(string v1, List<string> list1, int v2, List<int> list2)
    {
        description = v1;
        affectedCities = list1;
        effect = v2;
        auditions = list2;
    }

    public void Execute()
    {
        
    }
}
