using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chart : MonoBehaviour {

    LineRenderer lr;
    public GameObject currentCity;

    void Start()
    {
        lr = GetComponent<LineRenderer>();


    }


    public void Tick()
    {
        int x = 0;
        float chartX = 0;
        City c = currentCity.GetComponent<City>();
        foreach (int y in c.moodHistory)
        {
            float chartY = translate(y, 0, 1000, 0, 20);
            lr.SetPosition(x, new Vector3(chartX, chartY, 0));
            x++;
            chartX += 0.4f;
        }
    }

    float translate(float value, float leftMin, float leftMax, float rightMin, float rightMax) {
        float leftSpan = leftMax - leftMin;
        float rightSpan = rightMax - rightMin;
        float valueScaled = (float)(value - leftMin) / (float)(leftSpan);
        return rightMin + (valueScaled * rightSpan);
        }
}
