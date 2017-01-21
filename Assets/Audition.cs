using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audition : MonoBehaviour {

    bool unlocked = true;

    TextMesh textMesh;

    [SerializeField]
    int id = 1;

    [SerializeField]
    string name = "UnnamedAudition";


    void Start () {
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = name;
	}
	
	void Update () {
		
	}
}
