using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEventManager : MonoBehaviour {

    Dictionary<DateTime, GameEvent> dateEvents;

    void Start()
    {
        dateEvents = new Dictionary<DateTime, GameEvent>()
        {
            { new DateTime(1956,11,1,12,0,0),
                new GameEvent()
            },
            { new DateTime(1956,12,1,12,0,0),
                new GameEvent()
            },
            { new DateTime(1957,10,1,12,0,0),
                new GameEvent()
            }
        };
    }

    public void Tick()
    {

    }
}
