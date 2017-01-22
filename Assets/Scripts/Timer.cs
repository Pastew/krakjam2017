using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour {

    [SerializeField]
    private int tickEverySeconds = 1;

    [SerializeField]
    private int hoursAddedEveryTick = 1;


    private DateTime dateValue;
    private int ticks = 0;
    Cities cities;
    Antennas antennas;
    GameEventManager gameEventManager;

    private TextMesh textMesh;

    void Start () {
        dateValue = new DateTime(1972, 4, 15, 12, 0, 0);

        InvokeRepeating("Tick", 0, tickEverySeconds);

        textMesh = GetComponent<TextMesh>();
        cities = FindObjectOfType<Cities>();
        antennas = FindObjectOfType<Antennas>();
        gameEventManager = FindObjectOfType<GameEventManager>();
    }

    internal string GetDateForDiary()
    {
        return dateValue.Year + "-" + dateValue.Month + "-" + dateValue.Day + " ";
    }

    internal DateTime GetDate()
    {
        return dateValue;
    }

    void Tick()
    {
        UpdateClock();
        cities.TickCities();
        antennas.TickAntennas();
        gameEventManager.Tick();
        FindObjectOfType<Government>().Tick();
        FindObjectOfType<Spies>().Tick();

        FindObjectOfType<ScoreManager>().Tick();
        FindObjectOfType<DataManager>().Tick();
        FindObjectOfType<Wallet>().Tick();
        FindObjectOfType<AgentPriceUpdateer>().Tick();
    }

    private void UpdateClock()
    {
        dateValue = dateValue.AddHours(hoursAddedEveryTick);
        textMesh.text = dateValue.ToString();
        ticks++;
        textMesh.text = dateValue.Year + "-" + dateValue.Month + "-" + dateValue.Day;
    }

    internal int GetTick()
    {
        return ticks;
    }

    public DateTime GetTommorowDate()
    {
        DateTime tommorow = dateValue.AddDays(1);
        return tommorow;
    }
}
