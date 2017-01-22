using UnityEngine;

public class AntennaControlPanelBroadcastReiceve : MonoBehaviour {
    [SerializeField]
    Sprite broadcastSprite;

    [SerializeField]
    Sprite receiveSprite;

    public bool unlocked = false;

    void OnMouseDown()
    {
        Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;

        if (currentSprite.Equals(broadcastSprite))
        {
            if (unlocked)
            {
                GetComponentInParent<AntennaControlPanel>().SwitchToReiceve();
                GetComponent<SpriteRenderer>().sprite = receiveSprite;
            }
        }
        else
        {
            GetComponentInParent<AntennaControlPanel>().SwitchToBroadcast();
            GetComponent<SpriteRenderer>().sprite = broadcastSprite;
        }

    }

    public void ChangeToBroadcast()
    {
        GetComponent<SpriteRenderer>().sprite = broadcastSprite;
    }

    public void ChangeToReceive()
    {
        if (unlocked)
            GetComponent<SpriteRenderer>().sprite = receiveSprite;
    }


    internal void Hide()
    {
        ChangeVisibility(false);
    }

    internal void Show()
    {
        if(unlocked)
            ChangeVisibility(true);
    }

    private void ChangeVisibility(bool visibility)
    {
        GetComponent<BoxCollider2D>().enabled = visibility;
        GetComponent<SpriteRenderer>().enabled = visibility;
    }

    private bool isVisible()
    {
        return GetComponent<BoxCollider2D>().enabled;
    }
}
