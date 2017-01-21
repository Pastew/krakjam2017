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
        enabled = false;
    }

    void Update () {
		
	}

    internal void turnOnAntenna()
    {
        on.SetActive(false);
        off.SetActive(true);
        selectedAntenna.turnOn();
    }

    internal void turnOffAntenna()
    {
        on.SetActive(true);
        off.SetActive(false);
        selectedAntenna.turnOff();
    }

    internal void SetSelectedAntenna(Antenna antenna)
    {
        this.enabled = true;
        selectedAntenna = antenna;
    }
}
