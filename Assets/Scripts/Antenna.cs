using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour {

    InfoPanel infoPanel;

    static int id = 0;
    private string antennaName;
    private GameObject wave;

    [SerializeField]
    private int radius = 10;
    private bool broadcasting;
    private bool turnedOn;

    void Start () {
        id++;
        antennaName = "#" + id.ToString();
        broadcasting = true;
        turnedOn = false;
        infoPanel = FindObjectOfType<InfoPanel>();
        wave = transform.Find("Wave").gameObject;
        turnOff();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            print("RIGHT CLICK");
            FindObjectOfType<Hand>().selectAntenna(gameObject);
        }
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("LEFT CLICK");

            PopulateInfoPanel();
            ShowAntennaControlPanel();
        }

    }

    private void ShowAntennaControlPanel()
    {
        AntennaControlPanel antennaCP = FindObjectOfType< AntennaControlPanel > ();
        antennaCP.SetSelectedAntenna(this);
    }

    private void PopulateInfoPanel()
    {
        string message = "Zasięg anteny: " + radius + "km\n";
        City[] cities = FindObjectOfType<Cities>().GetCites();

        print("---Odległość między miastami---");
        print("Miasta w zasięgu:");
        message += "Miasta w zasięgu:\n";
        foreach (City c in cities)
        {
            float distancekm = Utils.Distance2DinKm(c.transform.position, transform.position);
            if (distancekm <= radius)
            {
                print(c.getName() + ": " + distancekm + " jest w zasięgu!");
                message += c.getName() + "(" + (int)distancekm + ")km\n";
            }
        }

        print("Miasta poza zasięgiem:");
        foreach (City c in cities)
        {
            float distancekm = Utils.Distance2DinKm(c.transform.position, transform.position);
            if (distancekm > radius)
                print(c.getName() + ": " + distancekm + " jest poza zasiegiem");
        }

        infoPanel.SetText(message);
    }

    internal void OnAntennaPlaced()
    {
        PopulateInfoPanel();
        //TODO: TO się odpala gdy stawiamy antene na mapie. Można puścić jakiś dźwięk
    }

    internal string getName()
    {
        return antennaName;
    }

    public bool isTurnedOn()
    {
        return turnedOn;
    }

    public void turnOff()
    {
        print("Antena "+ antennaName + " turned off");
        turnedOn = false;
        if (wave)
        {
            wave.SetActive(false);
        }
    }

    public void turnOn()
    {
        print("Antena " + antennaName + " turned on");
        turnedOn = true;
        if (wave)
        {
            wave.SetActive(true);
        }
    }

    internal void SwitchToBroadcast()
    {
        broadcasting = true;
        wave.GetComponent<Animator>().SetTrigger("broadcast");
        print("Antena " + antennaName + " switched to broadcast mode");
    }

    internal void SwitchToReiceve()
    {
        broadcasting = false;
        wave.GetComponent<Animator>().SetTrigger("receive");
        print("Antena " + antennaName + " switched to receive mode");

    }

    public bool isBroadcasting()
    {
        return broadcasting;
    }

    public bool isReiceving()
    {
        return !broadcasting;
    }

    public void Tick()
    {
        if (isBroadcasting())
            affectCities();

        if (isReiceving())
            searchForSpies();
    }

    private void affectCities()
    {
        /*City[] cities = FindObjectOfType<Cities>().GetCites();

        foreach (City c in cities)
        {
            float distance = Vector3.Distance(c.transform.position, transform.position);

            print(c.getName() + ": " + distance + "\n");
        }*/
    }

    private void searchForSpies()
    {
        // Jak znajdziesz szpiega to zapal zolta lampke
    }
}
