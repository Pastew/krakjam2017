using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// efekt do wizyty Nixona
public class Effect5 : Effect {

    private double addition;

    public Effect5()
    {
        id = 5;
        lifeTime = 20;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }

        city.xA += (float)addition;
        counter++;
    }

    public override void recalculateData(City city)
    {
        float temp = (float)lifeTime;
        float param = 1 + (city.population - 100000) / 225000;
        lifeTime = (int)(param * temp);
        addition = 3 * ((11 - city.population / 100000) * 0.05 + 0.5);
    }
}
