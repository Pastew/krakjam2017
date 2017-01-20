using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour {

    [SerializeField]
    private int tickEverySeconds = 1;

    [SerializeField]
    private int hoursAddedEveryTick = 1;


    private DateTime dateValue;
    private float ticks = 0;

    private TextMesh textMesh;

    void Start () {
        dateValue = new DateTime(1952, 5, 3, 12, 0, 0);
        print(dateValue);
        InvokeRepeating("Tick", 0, tickEverySeconds);

        textMesh = GetComponent<TextMesh>();
    }
	
    void Tick()
    {
        dateValue = dateValue.AddHours(tickEverySeconds);
        textMesh.text = dateValue.ToString();
        ticks++;
        textMesh.text = dateValue.Hour + ":00\n" + dateValue.Year + "-" + dateValue.Month + "-" + dateValue.Day ;


    }

}
