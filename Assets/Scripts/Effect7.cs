using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// efekt audycji: Słowa wsparcia dla zamachowców
public class Effect7 : Effect {

    private double addition;

    public Effect7()
    {
        id = 7;
        lifeTime = 1;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        // CUSTOM Effect
        // bez wzgledu na ifa umieszczamy w tym miescie AGENTA
        if (city.getName() == 'Warszawa') {
            // jak w wawie to przypal, alarm
        } else {
            // jak poza wawa to mniejszy przypal
        }

        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }
        
        counter++;
    }

    public override void recalculateData(City city) {
          
    }
}
