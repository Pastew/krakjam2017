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

    void Start () {
        infoPanel = FindObjectOfType<InfoPanel>();
        GetComponentInChildren<TextMesh>().text = gameObject.name;
        this.setMood(0);

        float d = population / 10000 * 6;
        //this.offset = r.nextInt(d.intValue());
        offset = (int)UnityEngine.Random.Range(0f, d);
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
    }

    void OnMouseDown()
    {
        infoPanel.SetText(gameObject.name + "\nPopulacja: " + population);

    }

    internal object getName()
    {
        return gameObject.name;
    }
}
