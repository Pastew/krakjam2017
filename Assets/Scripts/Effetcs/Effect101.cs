using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect101 : EffectTemplate
{

    float addition;

    protected override void Awake()
    {
        base.Awake();
        addition = 0;
        id = 1;
        lifeTime = 15;
    }

    public override void Evaluate(City city)
    {
        base.Evaluate(city);
        city.xM += addition;
    }

    public override void Initialize(City city)
    {
        base.Initialize(city);
        RecalculateData(city);
    }

    protected override void RecalculateData(City city)
    {
        float param = 1 + (city.population - 100000) / 225000;
        lifeTime = (int)(param * lifeTime);
        addition = (float)(20 * ((11 - city.population / 100000) * 0.05 + 0.5));
    }
}
