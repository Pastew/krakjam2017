using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbToucher : MonoBehaviour {

    NormalLightBulb bulb;

    void Start()
    {
        bulb = FindObjectOfType<NormalLightBulb>();
    }

	void Update () {
		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = bulb.transform.position.z;
        transform.position = pos;

        if (Input.GetMouseButtonUp(0))
            transform.position = new Vector3(10000, 10000, 10000);
    }
}
