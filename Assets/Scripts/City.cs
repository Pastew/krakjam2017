using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {

    InfoPanel infoPanel;

    public int population = 100;

    public float mood = 100;

    private float delta = 5;
    private int offset;
    private float ownMood;
    private Effects effects;

    public float xM, xA;

    internal void Donate()
    {
        print("CITY DONATE");
        ScoreManager sm = FindObjectOfType<ScoreManager>();

        int money = (int)((sm.todayScore - sm.previousMonthScore) / 10000);
        money = (money > 0) ? money : 0;
        FindObjectOfType<Wallet>().AddMoney(money);
        sm.ResetPreviousScore();
    }

    internal void AddGovAttention(int v)
    {
        FindObjectOfType<Government>().attention += v;
    }

    internal void WriteToDiary(string v)
    {
        FindObjectOfType<Diary>().WriteToDiary(v);
    }

    internal bool isInAnyAntennaRange()
    {
        foreach (Antenna a in FindObjectsOfType<Antenna>())
        {
            if (Utils.Distance2DinKm(transform.position, a.transform.position) < a.radius)
                return true;
        }
        return false;
    }

    internal void PlaceSpyHere()
    {
        FindObjectOfType<Government>().ChangeSpyPosition(transform.position);
    }

    internal void InvokeGameEvent(string desc, int effect, string city, List<int> uditionTOAdd)
    {
        FindObjectOfType<GameEventManager>().AddNewEventForTommorow( desc,  effect,  city,  uditionTOAdd);
    }

    public List<float> moodHistory;

    public void RemoveEffect(int id)
    {
        effects.RemoveEffect(id);
    }

    void Start () {
        moodHistory = new List<float>();
        infoPanel = FindObjectOfType<InfoPanel>();
        GetComponentInChildren<TextMesh>().text = gameObject.name;
        setMood(0);

        float d = population / 10000 * 6;
        //this.offset = r.nextInt(d.intValue());
        offset = (int)UnityEngine.Random.Range(0f, d);
        effects = GetComponentInChildren<Effects>();
    }

    public void setMood(int tick)
    {
        delta = ownMood + calculateOtherWaves();
        mood += delta;
        mood = Mathf.Clamp(mood, -1000, 1000);
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
        xA = -1;
        xM = 1;

        GetComponentInChildren<Effects>().EvaluateEffects();

        setOwnMood(FindObjectOfType<Timer>().GetTick());

        UpdateColor();
    }

    private void UpdateColor()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float r = 0;
        float g = 0;
        float b = 0;

        // R <0, 255>
        // Mood <-1000, 1000>

        if (mood < 0)
        {
            r = -mood / 1000.0f*2;
        }
        else
        {
            g = mood / 1000.0f*2;

        }

        sr.color = new Color(r,g,b);
    }

    public void AfterTick()
    {
        setMood(FindObjectOfType<Timer>().GetTick());
        moodHistory.Add(mood);
    }

    void OnMouseDown()
    {
        infoPanel.SetCurrentTarget(this);
        PopulateInfoPanel();
    }

    private void PopulateInfoPanel()
    {
        string message = gameObject.name + "\nPopulacja: " + population + "\n";
        message += "Nastrój: " + (int)mood + "\n";
        message += "Trend: " + String.Format("{0:0.00}", delta) + "\n";

        message += "Efekty: " + effects.GetActiveEffectsCount() + " [" + effects.GetActiveEffectsListString() + "]\n";
        
        /*foreach (KeyValuePair<int, Effect> e in effectsDict)
        {
            message += e.Value.id + ". " + e.Value.counter + ", " + e.Value.lifeTime;
        }*/
        

        infoPanel.SetText(message);
    }

    internal object getName()
    {
        return gameObject.name;
    }

    internal void AddEffect(int effectID)
    {
        effects.AddEffectIfNotExistsElseResetCounter(effectID);
    }
}
