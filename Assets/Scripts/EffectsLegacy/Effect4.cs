using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect4 : Effect {

    private double addition;

    public Effect4()
    {
        id = 4;
        lifeTime = 1;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }
        
        city.Donate();
        counter++;
    }

    public override void recalculateData(City city) {
          
    }
}
