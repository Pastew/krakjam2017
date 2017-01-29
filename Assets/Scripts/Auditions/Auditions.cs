using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Auditions : MonoBehaviour
{
    private GameObject auditionsContainer;
    private AuditionFactory auditionFactory;

    void Start()
    {
        auditionsContainer = gameObject.GetComponentInChildren<GridLayoutGroup>().gameObject;
        auditionFactory = FindObjectOfType<AuditionFactory>();
        AddNewAuditionToPanelIfItDoesntExist(0);
        AddNewAuditionToPanelIfItDoesntExist(1);
        AddNewAuditionToPanelIfItDoesntExist(2);
    }

    public void RemoveAuditionsFromPanel(int[] ids)
    {
        foreach (int i in ids)
        {
            RemoveAuditionFromPanel(i);
        }
    }

    public void AddNewAuditionToPanelIfItDoesntExist(int id)
    {
        if (AuditionAlreadyExists(id))
            return;

        auditionFactory.CreateAudition(id, auditionsContainer.transform);
    }

    public void RemoveAuditionFromPanel(int id)
    {
        foreach (Audition a in auditionsContainer.GetComponentsInChildren<Audition>())
        {
            if (a.GetData() != null && a.GetID() == id)
            {
                Destroy(a.gameObject);
                return;
            }
        }
    }

    private bool AuditionAlreadyExists(int id)
    {
        foreach (Audition a in auditionsContainer.GetComponentsInChildren<Audition>())
            if (a.GetData() != null && a.GetID() == id) return true;

        return false;
    }

}
