using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaButton : MonoBehaviour {

    Hand hand;

    [SerializeField]
    GameObject antenna;

	void Start () {
        hand = FindObjectOfType<Hand>();
	}
	
	void Update () {
		
	}

    void OnMouseUp()
    {
        print("You chose antenna");
        GameObject newAntenna = Instantiate(antenna);
        newAntenna.GetComponent<Collider2D>().enabled = false;
        hand.selectAntenna(newAntenna);
    }
}
