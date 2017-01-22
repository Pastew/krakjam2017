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
        Wallet w = FindObjectOfType<Wallet>();
        if (w.money < 1500)
            return;

        w.AddMoney(-1500);
        w.updateMoney();

        GameObject newAntenna = Instantiate(antenna);
        newAntenna.GetComponent<Collider2D>().enabled = false;
        hand.selectAntenna(newAntenna);
    }
}
