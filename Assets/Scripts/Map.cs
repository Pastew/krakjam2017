using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    Hand hand;

	void Start () {
        hand = FindObjectOfType<Hand>();
	}
	
	void Update () {
		
	}

    void OnMouseUp()
    {
        hand.placeAntenna();
    }
}
