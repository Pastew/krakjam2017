using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// efekt audycji: Audycja dokumentalna o USA
public class Effect10 : Effect {

    private double addition;

    public Effect10()
    {
        id = 10;
        lifeTime = 5;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        // uspokojenie (% -) ok. 3 sek, 10%
        // emituj event Prosby o wiecej audycji o USA. 
        // flav: Nadeszła fala prósb sluchaczy o wiecej USA w radio.
        if (counter == 0)
        {
            List<int> auditions = new List<int>() { 9, 10 };
            city.InvokeGameEvent("Audycja stała się popularna, słuchacze chcą więcej", 15, "Warszawa", auditions);
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