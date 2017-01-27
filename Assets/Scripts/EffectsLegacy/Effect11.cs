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
        lifeTime = 15;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        // zachecenie do dzialania (% +) ok. 2 sek, 15%
        if (counter == 0)
        {
            city.WriteToDiary("Ludzie s¹ zainspirowani, chc¹ walczyæ o wolnoœæ!");
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
