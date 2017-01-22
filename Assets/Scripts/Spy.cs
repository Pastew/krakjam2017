using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spy : MonoBehaviour {

    float x;
    float y;
    int threshold;
    int counter;

    public bool visible;

    Government gov;

    void Start () {
        transform.parent = FindObjectOfType<Spies>().transform;
        visible = false;
        ResetSpy();
    }
    
    private void ResetSpy()
    {
        gov = FindObjectOfType<Government>();
        counter = 0;
        x = Random.Range(0, 7);
        y = Random.Range(0, 7);
        threshold = Random.Range(10, 30);
        Vector2 pos = new Vector2(x, y);
        print("New spy spawned at " + pos);
        transform.position = pos;
    }

    public void Tick()
    {
        counter++;
        if(counter >= threshold)
        {
            ResetSpy();
        }
    }

    internal void stepSpy()
    {
    }

    public bool Receive()
    {
        if (!FindObjectOfType<TransmittionButton>().isTransmitting())
            return false;

        foreach (Antenna a in FindObjectsOfType<Antenna>())
        {
            if (a.isTurnedOn() && a.isBroadcasting())
            {
                if(Utils.Distance2DinKm(transform.position, a.transform.position) <= a.radius)
                {
                    gov.IncreaseAttention();
                    return true;
                }
            }
        }
        return false;
    }

    internal void Show()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        Invoke("Hide", 30);
    }

    internal void Hide()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
