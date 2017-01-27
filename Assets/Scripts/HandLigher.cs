using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLigher : MonoBehaviour {

    private Light light;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(2))
            light.enabled = !light.enabled;

    }
}
