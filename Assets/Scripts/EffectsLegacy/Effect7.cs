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
        lifeTime = 10;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        // CUSTOM Effect
        // bez wzgledu na ifa umieszczamy w tym miescie AGENTA
        if (city.getName() == "Warszawa") {
            // jak w wawie to przypal, alarm
            city.PlaceSpyHere();
        }

        if (counter == 0)
        {
            if (city.isInAnyAntennaRange())
            {
                city.WriteToDiary("Swoim nierozważnym działaniem zdenerwowałeś rząd");
                city.AddGovAttention(20);
            }
            else
            {
                city.WriteToDiary("Zamachowcy zostali złapani, jednak tobie udało się uciec.");
            }
        }

        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }

        city.xA += (float)addition;
        counter++;
    }

    public override void recalculateData(City city)
    {
        float temp = (float)lifeTime;
        float param = 1 + (city.population - 100000) / 225000;
        lifeTime = (int)(param * temp);
        addition = -4 * ((11 - city.population / 100000) * 0.05 + 0.5);
    }
}
