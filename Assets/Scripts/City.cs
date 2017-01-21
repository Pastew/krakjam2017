using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {

    InfoPanel infoPanel;

    [SerializeField]
    private int population = 100;

    [SerializeField]
    private int mood = 100;

    private double delta = 5;
    private int offset;
    private double ownMood;

    private Dictionary<int, Effect> effectsDict;

    private List<int> effectsToRemoveBeforeNextRound;

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

        effectsDict = new Dictionary<int, Effect>();
        effectsToRemoveBeforeNextRound = new List<int>();
    }

    public void setMood(int tick)
    {
        double temp = population / 10000 * 6;
        ownMood = 5 * Math.Sin((tick + offset) * (2 * Math.PI / temp));
        double sumOfInfluences = 0;
        /*
        for (int i = 0; i < influences.size(); i++)
        {
            double tempInf = influences.get(i).getInfluence(this.mood);
            if (tempInf == 0) influences.remove(i--);
            sumOfInfluences += tempInf;
        }
        */
        delta = ownMood + sumOfInfluences;
        mood += (int)delta;
    }

    void Update () {
		
	}

    internal void Tick()
    {
        foreach (KeyValuePair<int, Effect> e in effectsDict)
        {
            e.Value.evaluate(this);
        }

        foreach(int i in effectsToRemoveBeforeNextRound)
        {
            effectsDict.Remove(i);
        }
        effectsToRemoveBeforeNextRound.Clear();
    }

    void OnMouseDown()
    {
        PopulateInfoPanel();
    }

    private void PopulateInfoPanel()
    {
        string message = gameObject.name + "\nPopulacja: " + population + "\n";
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
