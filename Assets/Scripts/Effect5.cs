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
        lifeTime = 1;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        // emituj trzy aukcje-reakcje

        // AddNewAuditionToPanel(2, "Głos wytrwałości", effectDatabase.ProduceEffect(2), new int[] { });
        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }
        
        counter++;
    }

    public override void recalculateData(City city) {
          
    }
}
