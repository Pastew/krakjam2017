using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectTemplate : MonoBehaviour {

    protected Diary diary;
    protected int id;
    protected City city;
    public int counter;
    public int lifeTime;

    public abstract void Evaluate(City city);
    public abstract void RecalculateData(City city);

    internal int GetID()
    {
        return id;
    }


    public virtual void Start()
    {
    }

    internal void Initialize(City city)
    {
        this.city = city;
    }

    public virtual void Awake()
    {
        diary = FindObjectOfType<Diary>();
    }

    void Update () {
		
	}

}
