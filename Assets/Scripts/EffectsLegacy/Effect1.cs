using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect1 : Effect {

    private double addition;

    public Effect1()
    {
        id = 1;
        lifeTime = 7;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }

        city.xM += (float)addition;
        counter++;
    }

    public override void recalculateData(City city) {
        float temp = (float)lifeTime;
        float param = 1 + (city.population - 100000) / 225000;
        lifeTime = (int)(param * temp);
        addition = 20 * ((11 - city.population / 100000) * 0.05 + 0.5);    
    }
}
