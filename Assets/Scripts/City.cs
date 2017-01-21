using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {

    InfoPanel infoPanel;

    [SerializeField]
    private int population = 100;

    [SerializeField]
    private int comunismLevel = 100;

    void Start () {
        infoPanel = FindObjectOfType<InfoPanel>();
        GetComponentInChildren<TextMesh>().text = gameObject.name;
	}
	
	void Update () {
		
	}

    internal void Tick()
    {
    }

    void OnMouseDown()
    {
        infoPanel.SetText("Wybrane miasto: " + gameObject.name + "\nPopulacja: " + population);

    }

    internal object getName()
    {
        return gameObject.name;
    }
}
