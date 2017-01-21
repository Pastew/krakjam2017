using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaControlPanel : MonoBehaviour {

    AntennaControlPanelOnOff antennaControlPanelOnOff;
    AntennaControlPanelBroadcastReiceve antennaControlPanelBroadcastReiceve;
    Antenna selectedAntenna = null;

	void Start () {
        antennaControlPanelOnOff = GetComponentInChildren<AntennaControlPanelOnOff>();
        antennaControlPanelBroadcastReiceve = GetComponentInChildren<AntennaControlPanelBroadcastReiceve>();
        antennaControlPanelOnOff.Hide();
        antennaControlPanelBroadcastReiceve.Hide();
    }

    void Update () {
		
	}

    internal void TurnOnAntenna()
    {
        selectedAntenna.turnOn();
    }

    internal void SwitchToReiceve()
    {
        selectedAntenna.SwitchToReiceve();
    }

    internal void SwitchToBroadcast()
    {
        selectedAntenna.SwitchToBroadcast();
    }

    internal void TurnOffAntenna()
    {
        selectedAntenna.turnOff();
    }

    public void SetSelectedAntenna(Antenna antenna)
    {
        antennaControlPanelOnOff.Show();
        transform.Find("name").GetComponent<TextMesh>().text = "Antena " + antenna.getName();
        selectedAntenna = antenna;
        if (antenna.isTurnedOn())
        {
            antennaControlPanelOnOff.ChangeToON();
        }
        else
        {
            antennaControlPanelOnOff.ChangeToOFF();
        }

        antennaControlPanelBroadcastReiceve.Show();
        transform.Find("name").GetComponent<TextMesh>().text = "Antena " + antenna.getName();
        selectedAntenna = antenna;
        if (antenna.isBroadcasting())
        {
            antennaControlPanelBroadcastReiceve.ChangeToBroadcast();
        }
        else
        {
            antennaControlPanelBroadcastReiceve.ChangeToReceive();
        }
    }
}
