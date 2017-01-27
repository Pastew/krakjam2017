using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour {

    EffectFactory effectFactory;
    City city;

	void Awake () {
        effectFactory = FindObjectOfType<EffectFactory>();
        city = GetComponentInParent<City>();
    }
	
    public void EvaluateEffects()
    {
        foreach (EffectTemplate e in GetComponentsInChildren<EffectTemplate>())
            e.Evaluate(city);
    }

    internal void RemoveEffect(int id)
    {
        foreach (EffectTemplate e in GetComponentsInChildren<EffectTemplate>())
        {
            if (e.GetID() == id)
                Destroy(e.gameObject);
        }
    }

    internal int GetActiveEffectsCount()
    {
        return GetComponentsInChildren<EffectTemplate>().Length;
    }

    internal void AddEffectIfNotExistsElseResetCounter(int effectID)
    {
        if (EffectAlreadyExists(effectID)) ResetEffectCounter(effectID);
        else AddEffect(effectID);
    }

    private bool EffectAlreadyExists(int effectID)
    {
        foreach (EffectTemplate e in GetComponentsInChildren<EffectTemplate>())
            if (e.GetID() == effectID)
                return true;

        return false;
    }

    private void ResetEffectCounter(int effectID)
    {
        foreach (EffectTemplate e in GetComponentsInChildren<EffectTemplate>())
            if (e.GetID() == effectID)
                e.SetCounter(0);
    }

    private void AddEffect(int effectID)
    {
        EffectTemplate e = effectFactory.CreateEffect(effectID).GetComponent<EffectTemplate>();
        e.gameObject.transform.parent = transform;
        e.Initialize(city);
    }
}
