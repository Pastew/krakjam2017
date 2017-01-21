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

                print("Game Event: " + gameEvent.dateTime.Date);
                print("Timer: " + timer.GetDate().Date);
            }
                
        }
    }
}
