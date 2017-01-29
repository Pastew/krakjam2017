using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audition : MonoBehaviour {
    private AuditionData data;
    private Auditions auditions;

    void Start()
    {
        auditions = FindObjectOfType<Auditions>();
    }

    public void OnAuditionChosen()
    {
        print("I am audition with id " + GetID() + " and i was chosen! I want to remove these ids " );
        foreach (int i in data.idsToRemoveWhenChosen) { print(i); }
        auditions.RemoveAuditionsFromPanel(data.idsToRemoveWhenChosen);
        FindObjectOfType<CurrentAuditionHolder>().SetCurrentAudition(this);
    }

    public int GetEffectID()
    {
        return data.effectID;
    }

    public int GetID()
    {
        return data.id;
    }

    public string GetDescription()
    {
        return data.description;
    }

    internal void SetData(AuditionData data)
    {
        this.data = data;
    }

    internal object GetData()
    {
        return data;
    }
}
