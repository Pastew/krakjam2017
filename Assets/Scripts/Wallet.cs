using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour {

    public int money;

	void Start () {
        money = 20000;
        updateMoney();
    }

    public void Tick()
    {
        updateMoney();
    }
	
    public void updateMoney()
    {
        string message = "Konto: " + money + " PLN";
        FindObjectOfType<MoneyPanel>().GetComponent<Text>().text = message;

    }

    void Update () {
		
	}

    internal void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        print("AddMoney exetudec. WIll add: " + moneyToAdd);
        print("NEW money: " + money);
    }
}
