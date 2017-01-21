using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaControlPanelOnOff : MonoBehaviour {

    [SerializeField]
    private string action = "on";

	void Start () {
		
	}

    void OnMouseDown() { 
        if(action == "on")
            GetComponentInParent<AntennaControlPanel>().turnOnAntenna();
        else
            GetComponentInParent<AntennaControlPanel>().turnOffAntenna();
    }	

}
