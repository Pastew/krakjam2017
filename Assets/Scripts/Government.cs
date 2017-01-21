using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Government : MonoBehaviour {

    int attention;
    int agents;
    List<Spy> spies;

    void Start () {
        attention = 0;
        agents = 0;
        spies = new List<Spy>();
    }

    public void stepGov()
    {
        attention++;
        checkSpies();
    }

    public void checkSpies()
    {
        int i = attention;

        if (i > 0 && i <= 50 && spies.Count < 1) spies.Add(new Spy());
        else if (i > 50 && i <= 75 && spies.Count < 2) spies.Add(new Spy());
        else if (i > 75 && i <= 90 && spies.Count < 3) spies.Add(new Spy());
        else if (i > 90 && i <= 100 && spies.Count < 5) spies.Add(new Spy());


        if (i == 0 && spies.Count > 0) spies.Clear();
        else if (i > 0 && i <= 50 && spies.Count > 1) spies.RemoveAt(spies.Count - 1);
        else if (i > 50 && i <= 75 && spies.Count > 2) spies.RemoveAt(spies.Count - 1);
        else if (i > 75 && i <= 90 && spies.Count > 3)
        {

            if (spies.Count == 4) spies.RemoveAt(3);
            else if (spies.Count == 5) { spies.RemoveAt(4); spies.RemoveAt(3); }

        }
    }

    public void changeGov(int delta)
    {

        attention += delta;
        checkSpies();

    }

    public void stepSpies()
    {
        for (int i = this.spies.Count - 1; i >= 0; i--)
        {
            spies[i].stepSpy();
        }
    }

}
