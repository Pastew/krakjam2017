using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audition : MonoBehaviour {
    public static int nextID = 0;

    public bool unlocked = true;
    public int id;
    public string description = "No description provided";

    void Start()
    {
    }

    public int GetID()
    {
        return id;
    }

    public string GetDescription()
    {
        return description;
    }

    public void OnAuditionChosen()
    {
        print("I am audition with id " + GetID() + " and i was chosen!");
    }
}
