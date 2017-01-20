using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseUp()
    {
        FindObjectOfType<MoveCamera>().OpenLeftMenu();
    }
}
