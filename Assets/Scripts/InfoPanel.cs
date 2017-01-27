using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour {

    private TextMesh textMesh;
    private MonoBehaviour currentTarget;

    void Start () {
        textMesh = GetComponentInChildren<TextMesh>();
    }

    public void SetText(string text)
    {
        textMesh.text = text;
    }

    void OnMouseDown()
    {
    }

    public void Tick()
    {
        if(currentTarget != null)
            currentTarget.Invoke("PopulateInfoPanel", 0);
    }

    internal void SetCurrentTarget(MonoBehaviour newTarget)
    {
        currentTarget = newTarget;
    }

    public static bool HasMethod(object objectToCheck, string methodName)
    {
        var type = objectToCheck.GetType();
        return type.GetMethod(methodName) != null;
    }
}
