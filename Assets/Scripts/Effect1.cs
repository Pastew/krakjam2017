using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect1 : Effect {

    public Effect1()
    {
        id = 1;
        lifeTime = 10;
        counter = 0;
    }

    public override bool evaluate(City city)
    {
        if (counter >= lifeTime)
        {
            city.removeEffect(this);
            return false;
        }

        counter++;
        city.setMood(10);
        return true;
    }
}
