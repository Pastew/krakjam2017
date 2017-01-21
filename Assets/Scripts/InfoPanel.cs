using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour {

    TextMesh textMesh;

	void Start () {
        textMesh = GetComponent<TextMesh>();
	}

    public void SetText(string text)
    {
        textMesh.text = text;
    }

	void Update () {
		
	}
}
