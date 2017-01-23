using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFactory : MonoBehaviour {

    protected static EffectFactory instance;
    public GameObject[] effects;

    void Start()
    {
        instance = this;
    }

    public static EffectTemplate CreateEffect(int id, City city)
    {
        EffectTemplate effect = Instantiate(instance.effects[id], Vector3.zero, Quaternion.identity).GetComponent<EffectTemplate>();
        effect.Initialize(city);
        return effect;
    }
}
