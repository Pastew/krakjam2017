using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audition : MonoBehaviour {
    public static int nextID = 0;

    public bool unlocked = true;
    public int id;
    public int[] idsToRemoveWhenChosen;
    public string description = "No description provided";
    public Effect effect;

    private Auditions auditions;

    void Start()
    {
        auditions = FindObjectOfType<Auditions>();
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
        print("I am audition with id " + GetID() + " and i was chosen! I want to remove these ids " );
        foreach (int i in idsToRemoveWhenChosen) { print(i); }
        auditions.RemoveAuditionFromPanel(idsToRemoveWhenChosen);
        FindObjectOfType<CurrentAuditionHolder>().SetCurrentAudition(this);
    }

    internal Effect GetEffect()
    {
        return effect;
    }
}
