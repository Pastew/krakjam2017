using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaControlPanelOnOff : MonoBehaviour {
    [SerializeField]
    Sprite onSprite;

    [SerializeField]
    Sprite offSprite;

    void OnMouseDown()
    {
        Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;

        if (currentSprite.Equals(onSprite))
        {
            GetComponentInParent<AntennaControlPanel>().TurnOffAntenna();
            GetComponent<SpriteRenderer>().sprite = offSprite;
        }
        else
        {
            GetComponentInParent<AntennaControlPanel>().TurnOnAntenna();
            GetComponent<SpriteRenderer>().sprite = onSprite;
        }

    }

    internal void Hide()
    {
        ChangeVisibility(false);
    }

    internal void Show()
    {
        ChangeVisibility(true);
    }

    private void ChangeVisibility(bool visibility)
    {
        GetComponent<BoxCollider2D>().enabled = visibility;
        GetComponent<SpriteRenderer>().enabled = visibility;
    }

    public void ChangeToON()
    {
            
        GetComponent<SpriteRenderer>().sprite = onSprite;
    }

    private bool isVisible()
    {
        return GetComponent<BoxCollider2D>().enabled;
    }

    public void ChangeToOFF()
    {
        GetComponent<SpriteRenderer>().sprite = offSprite;
    }

}
