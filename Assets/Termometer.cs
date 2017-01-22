using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Termometer : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void SetLevel(float level)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, level);
    }
}
