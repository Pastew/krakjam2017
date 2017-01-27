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
        lifeTime = 20;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        // komunizm dostaje flat plus ale nieduzy 
        // (w miare neutralny efekt)

        if (counter == 0)
        {
            city.WriteToDiary("Dzięki potępieniu zamachu \nuratowałeś konspirantów przed łapanką");
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
