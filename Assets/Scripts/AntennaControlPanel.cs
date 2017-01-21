using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaControlPanel : MonoBehaviour {

    GameObject on, off;
    Antenna selectedAntenna = null;

	void Start () {
        on = gameObject.transform.Find("on").gameObject;
        off = gameObject.transform.Find("off").gameObject;
        on.SetActive(false);
        off.SetActive(false);
    }

    void Update () {
		
	}

    internal void turnOnAntenna()
    {
        on.SetActive(true);
        off.SetActive(false);
        selectedAntenna.turnOn();
    }

    internal void turnOffAntenna()
    {
        on.SetActive(false);
        off.SetActive(true);
        selectedAntenna.turnOff();
    }

    public void SetSelectedAntenna(Antenna antenna)
    {
        transform.Find("name").GetComponent<TextMesh>().text = "Antena " + antenna.getName();
        selectedAntenna = antenna;
        if (antenna.isTurnedOn())
        {
            on.SetActive(true);
            off.SetActive(false);
        }
        else
        {
            on.SetActive(false);
            off.SetActive(true);
        }
    }
}
