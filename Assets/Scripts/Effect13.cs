using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// efekt audycji: Pocieszenie narodu
public class Effect13 : Effect {

    private double addition;

    public Effect13()
    {
        id = 13;
        lifeTime = 1;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        // CUSTOM Effect
        // uspokojenie (% -) 15% na 10sek

        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }
        
        counter++;
    }

    public override void recalculateData(City city) {
          
    }
}
