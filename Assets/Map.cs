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
        print("Map: onmouseup");
        hand.placeAntenna();
    }
}
