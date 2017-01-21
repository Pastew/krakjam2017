using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Auditions : MonoBehaviour {

    List<Audition> auditions;
    public Button auditionButtonPrefab;

	void Start () {
        AddNewAuditionToPanel(Audition.nextID++, "Jakas aydycja");
        AddNewAuditionToPanel(Audition.nextID++, "J22akas aydycja");
        AddNewAuditionToPanel(Audition.nextID++, "J33akas aydycja");
        AddNewAuditionToPanel(Audition.nextID++, "Ja44kas aydycja");
        AddNewAuditionToPanel(Audition.nextID++, "Jak55as aydycja");
        AddNewAuditionToPanel(Audition.nextID++, "Jak55as aydycja");
        AddNewAuditionToPanel(Audition.nextID++, "Jak55as aydycja");
        AddNewAuditionToPanel(Audition.nextID++, "Jak55as aydycja");
        AddNewAuditionToPanel(Audition.nextID++, "Jak55as aydycja");
    }
	
	void Update () {
		
	}


    public void AddNewAuditionToPanel(int id, string desc)
    {
        Transform parent = GetComponentInChildren<ContentSizeFitter>().gameObject.transform;
        Button newAudition = Instantiate(auditionButtonPrefab, parent, false);
        Audition audition = newAudition.gameObject.AddComponent<Audition>();
        audition.id = id;
        audition.description = desc;
        newAudition.GetComponentInChildren<Text>().text = audition.GetDescription();
        Button b = newAudition.GetComponent<Button>();
        b.onClick.AddListener(() => { AuditionClicked(audition); });

    }

    public void AuditionClicked(Audition audition)
    {
        audition.OnAuditionChosen();
    }
}
