using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {

    public int cost = 100;
    public bool unlocked = true;

    Wallet wallet;

	void Start () {
        UpdatePrice();
        wallet = FindObjectOfType<Wallet>();
    }

    internal void SetCost(int newCost)
    {
        cost = newCost;
        UpdatePrice();

    }

    void Tick()
    {
    }

    void OnMouseDown()
    {
        Use();
    }

    private void Use()
    {
        if (!unlocked)
            return;

        int availMoney = wallet.money;
        if(availMoney < cost)
        {
            return;
        }
        wallet.AddMoney(-cost);

        if (gameObject.name.Equals("Frequency"))
            UpgradeFrequency();
        if (gameObject.name.Equals("Receivers"))
            UpgradeReceivers();
        if (gameObject.name.Equals("Power"))
            UpgradePower();
    }

    private void UpgradePower()
    {
        foreach (Antenna a in FindObjectsOfType<Antenna>()){
            a.radius *= 1.1f;
        }
        cost = (int)(cost * 1.5f);
        UpdatePrice();
    }

    private void UpgradeReceivers()
    {
        FindObjectOfType<AntennaControlPanelBroadcastReiceve>().unlocked = true;
        cost = 0;
        UpdatePrice();
    }

    private void UpgradeFrequency()
    {
    }

    void UpdatePrice()
    {
        if(cost == 0)
            GetComponentInChildren<TextMesh>().text = "wykupione!";
        else
            GetComponentInChildren<TextMesh>().text = cost.ToString() + " PLN";
    }
}
