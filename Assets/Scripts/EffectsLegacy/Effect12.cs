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
        if (counter == 0)
        {
            city.WriteToDiary("Rząd już tak bardzo Cię nie podejrzewa");
            city.AddGovAttention(-5);
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
        addition = -0.2 * ((11 - city.population / 100000) * 0.05 + 0.5);
    }
}
