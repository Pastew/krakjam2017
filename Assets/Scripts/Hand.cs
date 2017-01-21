using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    GameObject antennaInHand = null;
    Antennas antennas;

	void Start () {
        antennas = FindObjectOfType<Antennas>();
	}
	
	void Update () {
        if (antennaInHand != null)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            antennaInHand.transform.position = pos;

        }
	}

    public void selectAntenna(GameObject antenna)
    {
        antennaInHand = antenna;
        antennaInHand.transform.SetParent(transform);
    }

    public void placeAntenna()
    {
        if (antennaInHand != null)
        {
            print("Placing antenna");
            antennaInHand.transform.SetParent(antennas.transform);
            antennaInHand.GetComponent<Collider2D>().enabled = true;
            antennas.RefreshAntennaList();
            antennaInHand = null;
        }
    }
}
