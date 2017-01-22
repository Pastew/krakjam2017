using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Government : MonoBehaviour {

    int MAX_ATTENTION = 100;
    int MIN_ATTENTION = 0;
    public int attention;
    public int agents, agentTimer;
    List<GameObject> spies;
    public Sprite spySprite;


    public int agentsRemovalCounter;

    void Start () {
        agentsRemovalCounter = 0;
        attention = 1;
        agents = 0;
        spies = new List<GameObject>();
        agentTimer = 0;
    }

    public void stepGov()
    {
        attention++;
        checkSpies();
    }

    public void checkSpies()
    {
        int i = attention;
        if (i > 0 && i <= 50 && spies.Count < 1) spies.Add(GenerateSpy());
        else if (i > 50 && i <= 75 && spies.Count < 2) spies.Add(GenerateSpy());
        else if (i > 75 && i <= 90 && spies.Count < 3) spies.Add(GenerateSpy());
        else if (i > 90 && i <= 100 && spies.Count < 5) spies.Add(GenerateSpy());


        if (i == 0 && spies.Count > 0) spies.Clear();
        else if (i > 0 && i <= 50 && spies.Count > 1) spies.RemoveAt(spies.Count - 1);
        else if (i > 50 && i <= 75 && spies.Count > 2) spies.RemoveAt(spies.Count - 1);
        else if (i > 75 && i <= 90 && spies.Count > 3)
        {
            if (spies.Count == 4) spies.RemoveAt(3);
            else if (spies.Count == 5) { spies.RemoveAt(4); spies.RemoveAt(3); }

        }
    }

    internal int HireAgent()
    {
        agents++;
        return agents;
    }

    private GameObject GenerateSpy()
    {
        GameObject spy = new GameObject();
        spy.name = "Spy";
        spy.AddComponent<Spy>();
        spy.AddComponent<SpriteRenderer>();
        spy.GetComponent<SpriteRenderer>().sprite = spySprite;
        spy.GetComponent<Spy>().Hide();
        return spy;
    }

    internal void IncreaseAttention()
    {
        attention += 1;
    }

    public void changeGov(int delta)
    {
        attention += delta;
        checkSpies();
    }

    public void Tick()
    {
        checkSpies();
        searchForSmellingBastardsFromResistance();
        agentsAction();
        FindObjectOfType<Termometer>().SetLevel(attention / 100f);
    }

    private void searchForSmellingBastardsFromResistance()
    {
        foreach(Spy s in FindObjectOfType<Spies>().GetComponentsInChildren<Spy>())
        {
            if (s.Receive())
                break;
        }

    }

    private void agentsAction()
    {
        agentTimer++;
        if (agentTimer >= 30)
        {
            agentTimer = 0;
            if (agents == 0)
                return;

            int x = Random.Range(1, 101);
            if (x <= (agents * 2))
            {
                ShowSpies();
            }
            else if (x > 100 - agents)
            {
                agents--;
                agentsRemovalCounter++;
                FindObjectOfType<Diary>().WriteToDiary("Rząd wykrył i pozbył się agenta");
            }
        }
    }

    private void ShowSpies()
    {
        foreach (GameObject s in spies)
        {
            s.GetComponent<Spy>().Show();
        }
    }
}
