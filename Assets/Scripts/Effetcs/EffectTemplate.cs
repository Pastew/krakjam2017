using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTemplate : MonoBehaviour {

    protected Diary diary;
    protected int id;
    protected City city;
    protected int counter;
    protected int lifeTime;

    protected virtual void Awake()
    {
        id = 0;
        lifeTime = 10;
        counter = 0;

        diary = FindObjectOfType<Diary>();
    }

    public virtual void Evaluate(City city)
    {
        if (counter >= lifeTime)
        {
            Destroy(gameObject);
        }

        counter++;
    }

    protected virtual void RecalculateData(City city)
    {
        Debug.Log("EffectTemplate does NOT know how to recalculate data");
    }

    internal int GetID()
    {
        return id;
    }

    public virtual void Initialize(City city)
    {
        this.city = city;
    }

    internal void SetCounter(int counterValue)
    {
        counter = counterValue;
    }
}
