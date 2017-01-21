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
        AddNewAuditionToPanel(0);
        AddNewAuditionToPanel(1);
        AddNewAuditionToPanel(2);
    }

    public void RemoveAuditionFromPanel(int[] ids)
    {
        foreach(int i in ids)
        {
            RemoveAuditionFromPanel(i);
        }
    }

    internal void AddNewAuditionToPanel(int i)
    {
        switch (i)
        {
            case 0:
                AddNewAuditionToPanel(0, "Głos wolności", effectDatabase.ProduceEffect(0), new int[] { 1 });
                break;
            case 1:
                AddNewAuditionToPanel(1, "Głos czynu", effectDatabase.ProduceEffect(1), new int[] { });
                break;
            case 2:
                AddNewAuditionToPanel(2, "Głos wytrwałości", effectDatabase.ProduceEffect(2), new int[] { 0, 1, 2 });
                break;
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
        if (auditionsDict.ContainsKey(id))
            return;

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

    public void AuditionClicked(Audition audition)
    {
        audition.OnAuditionChosen();
    }
}
