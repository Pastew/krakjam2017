using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// efekt audycji: Pochwala amerykanskiego snu
public class Effect11 : Effect {

    private double addition;

    public Effect11()
    {
        id = 11;
        lifeTime = 1;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        // zachecenie do dzialania (% +) ok. 2 sek, 15%

        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }
        
        counter++;
    }

    public override void recalculateData(City city) {
          
    }
}
