using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Auditions : MonoBehaviour {

    Dictionary<int, Audition> auditionsDict;
    public Button auditionButtonPrefab;

    EffectDatabase effectDatabase;

	void Start () {
        effectDatabase = FindObjectOfType<EffectDatabase>();
        auditionsDict = new Dictionary<int, Audition>();

        AddNewAuditionToPanel(0, "Głos wolności", effectDatabase.GetEffect(0), new int[] {1});
        AddNewAuditionToPanel(1, "Głos czynu", effectDatabase.GetEffect(1), new int[] { });
        AddNewAuditionToPanel(2, "Głos wytrwałości", effectDatabase.GetEffect(2),new int[] {0,1,2});
        print("CHU");

    }

    public void RemoveAuditionFromPanel(int[] ids)
    {
        foreach(int i in ids)
        {
            RemoveAuditionFromPanel(i);
        }
    }

    public void RemoveAuditionFromPanel(int id)
    {
        foreach (KeyValuePair<int, Audition> a in auditionsDict)
        {
            if(a.Key == id)
            {
                a.Value.gameObject.SetActive(false);
                auditionsDict.Remove(a.Key);
                return;
            }
        }
    }

    public void AddNewAuditionToPanel(int id, string desc, Effect effect, int[] idsToRemoveWhenChosen )
    {
        Transform parent = GetComponentInChildren<ContentSizeFitter>().gameObject.transform;
        Button newAudition = Instantiate(auditionButtonPrefab, parent, false);
        Audition audition = newAudition.gameObject.AddComponent<Audition>();
        auditionsDict.Add(id, audition);
        audition.id = id;
        audition.description = desc;
        audition.effect = effect;
        audition.idsToRemoveWhenChosen = idsToRemoveWhenChosen;
        newAudition.GetComponentInChildren<Text>().text = audition.GetDescription();
        Button b = newAudition.GetComponent<Button>();
        b.onClick.AddListener(() => { AuditionClicked(audition); });

    }
    /* Potrzebne to? Czy wyzej dodaje juz?
    internal void AddAudition(Audition audition)
    {
        auditions.Add(audition);
    }*/

    public void AuditionClicked(Audition audition)
    {
        audition.OnAuditionChosen();
    }
}
