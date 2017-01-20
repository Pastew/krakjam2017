using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMultiplierButton : MonoBehaviour {

    [SerializeField]
    private int mutliplyBy = 1;

	void OnMouseDown()
    {
        Time.timeScale = mutliplyBy;
        print("New time scale: " + Time.timeScale);
    }
}
