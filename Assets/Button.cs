using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    [SerializeField]
    private string panelToOpen;


    void Start () {
	}
	
	void Update () {
		
	}

    void OnMouseUp()
    {
        if(panelToOpen == "left")
            FindObjectOfType<MoveCamera>().OpenLeftMenu();
        if (panelToOpen == "right")
            FindObjectOfType<MoveCamera>().OpenRightMenu();
        if (panelToOpen == "top")
            FindObjectOfType<MoveCamera>().OpenTopMenu();
        if (panelToOpen == "bottom")
            FindObjectOfType<MoveCamera>().OpenBottomMenu();
        if (panelToOpen == "main")
            FindObjectOfType<MoveCamera>().OpenMain();
    }
}
