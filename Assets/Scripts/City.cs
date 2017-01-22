using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {

    InfoPanel infoPanel;

    [SerializeField]
    private int population = 100;

    [SerializeField]
    private float mood = 100;

    private float delta = 5;
    private int offset;
    private float ownMood;

    private Dictionary<int, Effect> effectsDict;

    private List<int> effectsToRemoveBeforeNextRound;

    public float xM, xA;

    public void RemoveEffect(int id)
    {
        effectsToRemoveBeforeNextRound.Add(id);
    }

    void Start () {
        infoPanel = FindObjectOfType<InfoPanel>();
        GetComponentInChildren<TextMesh>().text = gameObject.name;
        setMood(0);

        float d = population / 10000 * 6;
        //this.offset = r.nextInt(d.intValue());
        offset = (int)UnityEngine.Random.Range(0f, d);
        if(name.Equals("Warszawa"))
            print(name + " starting offset: " + offset);
        effectsDict = new Dictionary<int, Effect>();
        effectsToRemoveBeforeNextRound = new List<int>();
    }

    public void setMood(int tick)
    {
        delta = ownMood + calculateOtherWaves();
        mood += delta;
        if (name.Equals("Warszawa"))
            print(name + " mood: " + mood + " ownMod: " + ownMood + " delta: " + delta);
    }
    
    public void setOwnMood(int tick)
    {
        float temp = population / 10000 * 6;
        ownMood = (float)(2 * xM * Math.Sin((tick + offset) * (2 * Math.PI / temp)) + xA);
    }

    static float X = 7 / 9.5f;
    private float calculateOtherWaves()
    {
        float sum = 0;
        foreach(City city in FindObjectsOfType<City>())
        {
            if (city.name.Equals(name))
                continue;

            float populationRatio = (float)city.population / (2 * (float)population);
            float distance = Utils.Distance2D(transform.position, city.transform.position);
            float rate = distance / X;

            sum += (1 / (0.5f + rate) * populationRatio) * city.ownMood;
        }

        return sum;
    }

    internal void Tick()
    {
        xA = 0;
        xM = 1;

        foreach (KeyValuePair<int, Effect> e in effectsDict)
        {
            e.Value.evaluate(this);
        }

        setOwnMood(FindObjectOfType<Timer>().GetTick());

        foreach (int i in effectsToRemoveBeforeNextRound)
        {
            effectsDict.Remove(i);
        }
        effectsToRemoveBeforeNextRound.Clear();

    }

    public void AfterTick()
    {
        setMood(FindObjectOfType<Timer>().GetTick());
    }

    void OnMouseDown()
    {
        PopulateInfoPanel();
    }

    private void PopulateInfoPanel()
    {
        string message = gameObject.name + "\nPopulacja: " + population + "\n";
        message += "Mood: " + mood + "\n";
        message += "OwnMood: " + ownMood;

        message += "Efekty:\n";
        foreach (KeyValuePair<int, Effect> e in effectsDict)
        {
            message += e.Value.id + ". " + e.Value.counter + ", " + e.Value.lifeTime;
        }
        

        infoPanel.SetText(message);
    }

    internal object getName()
    {
        return gameObject.name;
    }

    internal void AddEffect(Effect effect)
    {
        if (effectsDict.ContainsKey(effect.id))
        {
            effectsDict[effect.id].counter = 0;
        }
        else
        {
            Effect newEffect = FindObjectOfType<EffectDatabase>().ProduceEffect(effect.id);
            effectsDict.Add(effect.id, newEffect);
        }

    }
}
