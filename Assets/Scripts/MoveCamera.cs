using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
	
	void Update () {
		
	}

    public void OpenMain()
    {
        MoveCameraToVec3(new Vector3(0, 0, 0));
    }

    public void OpenLeftMenu()
    {
        MoveCameraToVec3(new Vector3(-10f, 0, 0));
    }

    public void OpenRightMenu()
    {
        MoveCameraToVec3(new Vector3(10f, 0, 0));
    }

    public void OpenTopMenu()
    {
        MoveCameraToVec3(new Vector3(0, 7, 0));
    }

    public void OpenBottomMenu()
    {
        MoveCameraToVec3(new Vector3(0, -5.5f, 0));
    }

    public void OpenBottomLeft()
    {
        MoveCameraToVec3(new Vector3(-10f, -7f, 0));
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
