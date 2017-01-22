using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// efekt audycji: Wyolbrzymienie problemów USA
public class Effect12 : Effect {

    private double addition;

    public Effect12()
    {
        id = 12;
        lifeTime = 1;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        // CUSTOM Effect
        // spuszczenie troszke temp. z termometru (uspokojenie rzadu)

        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }
        
        counter++;
    }

    public override void recalculateData(City city) {
          
    }
}
