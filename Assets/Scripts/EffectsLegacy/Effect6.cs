using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// efekt do Krytyki amerykanskiego kapitalizmu (audycji)
public class Effect6 : Effect {

    private double addition;

    public Effect6()
    {
        id = 6;
        lifeTime = 1;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        // TODO
        // emituj EVENT: Plan zamachu - Wywrotowcy planują zamach na Nixona
        List<int> auditions = new List<int>() { 6, 7 , 8};
        city.InvokeGameEvent("Wywrotowcy planują zamach na Nixona", 11, "Warszawa", auditions);
        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }
        counter++;
    }

    public override void recalculateData(City city) {
          
    }
}
