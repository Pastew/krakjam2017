using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {

    ScreenDebug screenDebug;

    [SerializeField]
    private string name = "Unnamed";

    [SerializeField]
    private int population = 100;

    void Start () {
        screenDebug = FindObjectOfType<ScreenDebug>();
        GetComponentInChildren<TextMesh>().text = name;
	}
	
	void Update () {
		
	}

    void OnMouseDown()
    {
        screenDebug.write("Wybrane miasto: " + name + "\nPopulacja: " + population);

    }

    internal object getName()
    {
        return name;
    }
}
