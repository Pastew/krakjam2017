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

    internal Effect ProduceEffect(int v)
    {
        return new Effect1();
    }
}
