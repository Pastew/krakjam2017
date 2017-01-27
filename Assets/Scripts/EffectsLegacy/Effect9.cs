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
        lifeTime = 20;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        // audycja fałszywka zeby zmylic służby
        // emituj event Zamach powiódł się. Nixon ranny.

        // % + spory chaos
        if(counter == 0)
        {
            city.WriteToDiary("Dzięki zmyleniu służb \nzamach się powiódł, prezydent nie żyje.");
        }
        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }

        city.xM += (float)addition;
        counter++;
    }

    public override void recalculateData(City city)
    {
        float temp = (float)lifeTime;
        float param = 1 + (city.population - 100000) / 225000;
        lifeTime = (int)(param * temp);
        addition = 0.3 * ((11 - city.population / 100000) * 0.05 + 0.5);
    }
}