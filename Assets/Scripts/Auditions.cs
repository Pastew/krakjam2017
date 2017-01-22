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
                AddNewAuditionToPanel(0, "Głos wolności", effectDatabase.ProduceEffect(0), new int[] { });
                break;
            case 1:
                AddNewAuditionToPanel(1, "Głos czynu", effectDatabase.ProduceEffect(1), new int[] { });
                break;
            case 2:
                AddNewAuditionToPanel(2, "Głos wytrwałości", effectDatabase.ProduceEffect(2), new int[] { });
                break;
            case 3:
                AddNewAuditionToPanel(3, "Krytyka kapitalizmu", effectDatabase.ProduceEffect(6), new int[] {3,4,5});
                break;
            case 4:
                AddNewAuditionToPanel(4, "Dokument o USA", effectDatabase.ProduceEffect(10), new int[] { 3, 4, 5 });
                break;
            case 5:
                AddNewAuditionToPanel(5, "Pocieszenie Narodu", effectDatabase.ProduceEffect(13), new int[] { 3, 4, 5 });
                break;
            case 6:
                AddNewAuditionToPanel(6, "Wsparcie zamachu", effectDatabase.ProduceEffect(7), new int[] { 6, 7, 8 });
                break;
            case 7:
                AddNewAuditionToPanel(7, "Potępienie zamachu", effectDatabase.ProduceEffect(8), new int[] { 6, 7, 8 });
                break;
            case 8:
                AddNewAuditionToPanel(8, "Oszukaj służby", effectDatabase.ProduceEffect(9), new int[] { 6, 7, 8 });
                break;
            case 9:
                AddNewAuditionToPanel(7, "Zachwyt Ameryką", effectDatabase.ProduceEffect(11), new int[] { 11, 12 });
                break;
            case 10:
                AddNewAuditionToPanel(8, "Wyolbrzymienie problemów USA", effectDatabase.ProduceEffect(12), new int[] { 11, 12 });
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
