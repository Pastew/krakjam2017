using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect2 : Effect {

    private float addition;

    public Effect2()
    {
        id = 1;
        lifeTime = 7;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        recalculateData();
        
        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }

        city.xM += addition;
        counter++;
    }

    public override void recalculateData(City city) {
        float param = 1 + (city.population - 100000) / 225000;
        lifeTime *= param;
        addition = 20 * ((11 - city.population / 100000) * 0.05 + 0.5);    
    }
}
