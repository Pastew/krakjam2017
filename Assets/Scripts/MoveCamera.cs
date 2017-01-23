using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    enum Menu { MAIN, LEFT, RIGHT, BOTTOM, TOP, BOTTOMLEFT };
    private Menu CurrentMenu;

    [Tooltip ("Screen switches when user clicks on the edge of the screen when this is set to True")]
    [SerializeField]
    private bool changeScreenOnScreenEdgeClick = true;

    [SerializeField]
    private int margin = 2;

    [Tooltip("1 - Left, 2 - Right, 3 - Middle, 0 - None")]
    [SerializeField]
    private int buttonToChangeMenu = 2;

    private int screenWidth, screenHeight;

    void Start()
    {
        CurrentMenu = Menu.MAIN;
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

	void Update () {
        if (changeScreenOnScreenEdgeClick)
        {
            ChangeScreenWhenUserReachesScreenEdge();
        }
    }

    private void ChangeScreenWhenUserReachesScreenEdge()
    {
        if (Input.GetButtonUp("GoUp")) TopEdgeReached();
        if (Input.GetButtonUp("GoDown")) BottomEdgeReached();
        if (Input.GetButtonUp("GoLeft")) LeftEdgeReached();
        if (Input.GetButtonUp("GoRight")) RightEdgeReached();

        if (buttonToChangeMenu == 0 || Input.GetMouseButtonDown(buttonToChangeMenu))
        {
            if (Input.mousePosition.x < screenWidth/5
                && Input.mousePosition.y < screenHeight / 5) BottomLeftEdgeReached();
            if (Input.mousePosition.x < screenWidth - screenWidth / 5
                && Input.mousePosition.y > screenHeight - screenHeight / 5) TopRightEdgeReached();

            if (Input.mousePosition.x > screenHeight - margin) RightEdgeReached();
            if (Input.mousePosition.x < 0 + margin) LeftEdgeReached();
            if (Input.mousePosition.y > screenHeight - margin) TopEdgeReached();
            if (Input.mousePosition.y < 0 + margin) BottomEdgeReached();
        }
    }

    private void TopRightEdgeReached()
    {
        if (CurrentMenu == Menu.BOTTOMLEFT) OpenMain();
    }

    private void BottomLeftEdgeReached()
    {
        if (CurrentMenu == Menu.MAIN) OpenBottomLeft();
    }

    private void BottomEdgeReached()
    {
        if (CurrentMenu == Menu.MAIN) OpenBottomMenu();
        if (CurrentMenu == Menu.TOP) OpenMain();
        if (CurrentMenu == Menu.LEFT) OpenBottomLeft();
    }

    private void TopEdgeReached()
    {
        if (CurrentMenu == Menu.MAIN) OpenTopMenu();
        if (CurrentMenu == Menu.BOTTOM) OpenMain();
    }

    private void LeftEdgeReached()
    {
        if (CurrentMenu == Menu.MAIN) OpenLeftMenu();
        if (CurrentMenu == Menu.RIGHT) OpenMain();
        if (CurrentMenu == Menu.BOTTOM) OpenLeftMenu();
    }

    private void RightEdgeReached()
    {
        if (CurrentMenu == Menu.MAIN) OpenRightMenu();
        if (CurrentMenu == Menu.LEFT) OpenMain();
        if (CurrentMenu == Menu.BOTTOMLEFT) OpenBottomMenu();
    }

    public void OpenMain()
    {
        MoveCameraToVec3(new Vector3(0, 0, 0));
        CurrentMenu = Menu.MAIN;
    }

    public void OpenLeftMenu()
    {
        MoveCameraToVec3(new Vector3(-10f, 0, 0));
        CurrentMenu = Menu.LEFT;
    }

    public void OpenRightMenu()
    {
        MoveCameraToVec3(new Vector3(10f, 0, 0));
        CurrentMenu = Menu.RIGHT;
    }

    public void OpenTopMenu()
    {
        MoveCameraToVec3(new Vector3(0, 7, 0));
        CurrentMenu = Menu.TOP;
    }

    public void OpenBottomMenu()
    {
        MoveCameraToVec3(new Vector3(0, -5.5f, 0));
        CurrentMenu = Menu.BOTTOM;
    }

    public void OpenBottomLeft()
    {
        MoveCameraToVec3(new Vector3(-10f, -7f, 0));
        CurrentMenu = Menu.BOTTOMLEFT;
    }

    public void MoveCameraToVec3(Vector3 destinationPos)
    {
        StartCoroutine(MoveOverSeconds(gameObject, new Vector3(destinationPos.x, destinationPos.y, transform.position.z), 0.2f));
    }

    public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }

}
