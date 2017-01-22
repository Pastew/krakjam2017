using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentPriceUpdateer : MonoBehaviour {

    public void Tick()
    {
        UpdatePrice();
    }

	public void UpdatePrice()
    {
        int newCost = 200 + FindObjectOfType<Government>().agentsRemovalCounter * 50;
        GetComponent<Upgrade>().SetCost(newCost);
    }
}
