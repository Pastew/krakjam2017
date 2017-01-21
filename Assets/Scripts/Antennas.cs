using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antennas : MonoBehaviour {

    Antenna[] antennas;

	void Start () {
        RefreshAntennaList();
    }
	
    internal void TickAntennas()
    {
        if (!FindObjectOfType<TransmittionButton>().isTransmitting())
            return;

        foreach (Antenna antenna in antennas)
        {
            if (antenna.isTurnedOn())
            {
                antenna.Tick();
            }
        }
    }
    
    public void RefreshAntennaList()
    {
        antennas = GetComponentsInChildren<Antenna>();
    }
}
