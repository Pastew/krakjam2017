using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {

    ScreenDebug screenDebug;

    [SerializeField]
    private int population = 100;

    [SerializeField]
    private int comunismLevel = 100;

    void Start () {
        screenDebug = FindObjectOfType<ScreenDebug>();
        GetComponentInChildren<TextMesh>().text = gameObject.name;
	}
	
	void Update () {
		
	}

    internal void Tick()
    {
        print("City tick: " + gameObject.name);
    }

    void OnMouseDown()
    {
        screenDebug.write("Wybrane miasto: " + gameObject.name + "\nPopulacja: " + population);

    }

    internal object getName()
    {
        return gameObject.name;
    }
}
