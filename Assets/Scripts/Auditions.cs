using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Auditions : MonoBehaviour {

    List<Audition> auditions;
    public Button auditionButtonPrefab;

    EffectDatabase effectDatabase;

	void Start () {
        effectDatabase = FindObjectOfType<EffectDatabase>();
        auditions = new List<Audition>();

        AddNewAuditionToPanel(0, "Głos wolności", effectDatabase.GetEffect(0));
        AddNewAuditionToPanel(1, "Głos czynu", effectDatabase.GetEffect(1));
        AddNewAuditionToPanel(2, "Głos wytrwałości", effectDatabase.GetEffect(2));

        RemoveAuditionFromPanel(1);
    }

    public void RemoveAuditionFromPanel(int id)
    {
        foreach(Audition a in auditions)
        {
            if(a.id == id)
            {
                a.gameObject.SetActive(false);
                auditions.Remove(a);
                return;
            }
        }
    }

    void Update () {
		
	}

    public void AddNewAuditionToPanel(int id, string desc, Effect effect)
    {
        Transform parent = GetComponentInChildren<ContentSizeFitter>().gameObject.transform;
        Button newAudition = Instantiate(auditionButtonPrefab, parent, false);
        Audition audition = newAudition.gameObject.AddComponent<Audition>();
        auditions.Add(audition);
        audition.id = id;
        audition.description = desc;
        audition.effect = effect;
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
