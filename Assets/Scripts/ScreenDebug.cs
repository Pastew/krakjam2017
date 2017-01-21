using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenDebug : MonoBehaviour {

	public void write(string message)
    {
        Text text = gameObject.GetComponent<Text>();
        text.text = message;
    }
}
