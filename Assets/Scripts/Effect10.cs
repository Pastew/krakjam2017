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
        lifeTime = 1;
        counter = 0;
        addition = 0;
    }

    public override void evaluate(City city)
    {
        // uspokojenie (% -) ok. 3 sek, 10%
        // emituj event Prosby o wiecej audycji o USA. 
        // flav: Nadeszła fala prósb sluchaczy o wiecej USA w radio.

        if (counter >= lifeTime)
        {
            city.RemoveEffect(id);
        }
        
        counter++;
    }

    public override void recalculateData(City city) {
          
    }
}
