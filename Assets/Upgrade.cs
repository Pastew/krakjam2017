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
    }

    private void UpgradeReceivers()
    {
        FindObjectOfType<AntennaControlPanelBroadcastReiceve>().unlocked = true;
    }

    private void UpgradeFrequency()
    {
    }

    void UpdatePrice()
    {
        GetComponentInChildren<TextMesh>().text = cost.ToString() + " PLN";
    }
}
