using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvent : MonoBehaviour {

    public string description;
    public List<string> affectedCities;
    public int effect;
    public List<int> auditions = null;
    [Tooltip("Format: yyyy-mm-dd")]
    public string date = null;
    public DateTime dateTime;

    Diary diary;

    void Start()
    {
        diary = FindObjectOfType<Diary>();
        if (date != null)
            dateTime = DateTime.Parse(date);
    }

    public void Execute()
    {
        diary.WriteToDiary("Wydarzenie: " + description);
        Destroy(gameObject);
    }
}
