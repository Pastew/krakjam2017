using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEventManager : MonoBehaviour {

    Timer timer;
    DateGameEvents dateGameEventsContainer;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        dateGameEventsContainer = GetComponentInChildren<DateGameEvents>();
    }

    public void Tick()
    {
        DateTime todayDate = timer.GetDate();
        GameEvent[] dateGameEvents = dateGameEventsContainer.GetComponentsInChildren<GameEvent>();
        foreach (GameEvent gameEvent in dateGameEvents)
        {
            if (gameEvent.dateTime != null)
            {
                if (gameEvent.dateTime.Date.Equals(timer.GetDate().Date))
                    gameEvent.Execute();

            }
                
        }
    }

    public void AddNewEvent(string description, DateTime datetime, int effect, GameObject[] affectedCities, List<int> auditions)
    {
        Transform parent = FindObjectOfType<DateGameEvents>().transform;
        GameObject go = new GameObject();
        go.transform.parent = parent;

        GameEvent gameEvent = go.AddComponent<GameEvent>();
        gameEvent.description = description;
        gameEvent.dateTime = datetime;
        gameEvent.effect = effect;
        gameEvent.affectedCities = affectedCities;
        gameEvent.auditions = auditions;
        gameEvent.date = datetime.Date.ToString();        
    }

    /**
     * 
     * Example use: FindObjectOfType<GameEventManager>().AddNewEventForTommorow("lalala", 1, "Warszawa", 1);
    **/
    public void AddNewEventForTommorow(string description, int effect, string affectedCityString, List<int> auditions)
    {
        DateTime tommorow = FindObjectOfType<Timer>().GetTommorowDate();

        GameObject[] affectedCities = new GameObject[] { GameObject.Find(affectedCityString) };
        AddNewEvent(description, tommorow, effect, affectedCities, auditions);
    }
   
}
