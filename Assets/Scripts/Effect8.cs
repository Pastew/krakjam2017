using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// efekt audycji: Potepienie zamachowców
public class Effect8 : Effect {

    private double addition;

    public Effect8()
    {
        id = 8;
        lifeTime = 1;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        // komunizm dostaje flat plus ale nieduzy 
        // (w miare neutralny efekt)

        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }
        
        counter++;
    }

    public override void recalculateData(City city) {
          
    }
}
