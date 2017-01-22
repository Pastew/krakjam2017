using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug : MonoBehaviour {

	void OnMouseDown()
    {
        FindObjectOfType<GameEventManager>().AddNewEventForTommorow("lalala", 1, "Warszawa", 1);
    }
}
