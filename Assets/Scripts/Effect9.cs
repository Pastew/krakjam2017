using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// efekt audycji: Zamachowcy zbierają się w Krakowie
public class Effect9 : Effect {

    private double addition;

    public Effect9()
    {
        id = 9;
        lifeTime = 1;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        // audycja fałszywka zeby zmylic służby
        // emituj event Zamach powiódł się. Nixon ranny.

        // % + spory chaos

        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }
        
        counter++;
    }

    public override void recalculateData(City city) {
          
    }
}
