using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentAuditionHolder : MonoBehaviour {

    Audition currentAudition;

	void Start () {
        currentAudition = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetCurrentAudition(Audition audition)
    {
        currentAudition = audition;
        GetComponent<TextMesh>().text = audition.GetDescription();
    }

    public Audition GetCurrentAudition()
    {
        return currentAudition;
    }
}
