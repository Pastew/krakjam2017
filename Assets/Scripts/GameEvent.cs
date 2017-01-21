using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvent : MonoBehaviour {

    public string description;
    public GameObject[] affectedCities;
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
        if(auditions != null)
        {
            AddAuditions(auditions);
        }
        Destroy(gameObject);

        AddEffect();
    }

    private void AddEffect()
    {
        foreach (GameObject go in affectedCities)
        {
            City c = go.GetComponent<City>();
            c.AddEffect(FindObjectOfType<EffectDatabase>().ProduceEffect(effect));
        }
    }

    private void AddAuditions(List<int> auditions)
    {
        foreach (int i in auditions)
            FindObjectOfType<Auditions>().AddNewAuditionToPanel(i);
    }

}
