using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect101 : EffectTemplate {

    public override void Start()
    {
        base.Start();
        diary.WriteToDiary("hehue");
    }

    public override void Awake()
    {
        base.Awake();
    }

    void Update () {
		
	}

    public override void Evaluate(City city)
    {
        throw new NotImplementedException();
    }

    public override void RecalculateData(City city)
    {
        throw new NotImplementedException();
    }
}
