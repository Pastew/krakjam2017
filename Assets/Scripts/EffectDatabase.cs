using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDatabase : MonoBehaviour {

    List<Effect> effects;

	void Start () {
        effects = new List<Effect>();

        Effect1 effect1 = new Effect1();
        effects.Add(effect1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal Effect ProduceEffect(int id)
    {
        switch (id)
        {
            case 0:
                return new Effect0();
            case 1:
                return new Effect1();
            case 2:
                return new Effect2();
            case 4:
                return new Effect4();
        }
        return new Effect1();
    }
}
