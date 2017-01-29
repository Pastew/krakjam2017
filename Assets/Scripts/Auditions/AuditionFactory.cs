using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuditionFactory : MonoBehaviour {

    public GameObject auditionPrefab;

    void Start()
    {
    }

    public Audition CreateAudition(int id, Transform parent)
    {
        GameObject auditionGO = Instantiate(auditionPrefab, parent, false);
        auditionGO.name = "Audition_" + id;

        Audition audition = auditionGO.GetComponent<Audition>();
        audition.SetData(AuditionDatabase.GetAuditionData(id));
        auditionGO.GetComponentInChildren<Text>().text = audition.GetDescription();

        Button b = auditionGO.GetComponent<Button>();
        b.onClick.AddListener(() => { AuditionClicked(audition); });

        return audition;
    }

    public void AuditionClicked(Audition audition)
    {
        audition.OnAuditionChosen();
    }
}
