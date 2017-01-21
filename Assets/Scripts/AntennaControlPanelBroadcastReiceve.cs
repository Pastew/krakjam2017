using UnityEngine;

public class AntennaControlPanelBroadcastReiceve : MonoBehaviour {
    [SerializeField]
    Sprite broadcastSprite;

    [SerializeField]
    Sprite receiveSprite;

    void OnMouseDown()
    {
        Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;

        if (currentSprite.Equals(broadcastSprite))
        {
            GetComponentInParent<AntennaControlPanel>().SwitchToReiceve();
            GetComponent<SpriteRenderer>().sprite = receiveSprite;
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
        GetComponent<SpriteRenderer>().sprite = receiveSprite;
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

    private bool isVisible()
    {
        return GetComponent<BoxCollider2D>().enabled;
    }
}
