using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spies : MonoBehaviour {
    internal void Tick()
    {
        foreach (Spy s in GetComponentsInChildren<Spy>())
            s.Tick();
    }
}
