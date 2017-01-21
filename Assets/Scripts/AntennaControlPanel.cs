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
        print("turrrasrsa");
        on.SetActive(true);
        off.SetActive(false);
        selectedAntenna.turnOn();
    }

    internal void turnOffAntenna()
    {
        print("offffffffff");

        on.SetActive(false);
        off.SetActive(true);
        selectedAntenna.turnOff();
    }

    public void SetSelectedAntenna(Antenna antenna)
    {
        selectedAntenna = antenna;
        if (antenna.isTurnedOn())
        {
            off.SetActive(true);
        }
        else
        {
            on.SetActive(true);
        }
    }
}
