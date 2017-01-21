using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalLightBulb : MonoBehaviour {

	void Update () {
		
	}

    void OnMouseDown()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = new Vector2(pos.x, pos.y);
        Vector2 bulbPos = transform.position;
        Vector2 sub = bulbPos - mousePos;

        float multiplier = 1000;
        Vector2 force = sub * multiplier;
        print("Got force: " + force);
        GetComponent<Rigidbody2D>().AddForce(force);
    }
}
