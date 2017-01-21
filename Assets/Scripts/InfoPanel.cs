using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour {

    private TextMesh textMesh;
    private Animator animator;
    private bool isVisible = true;

    void Start () {
        textMesh = GetComponentInChildren<TextMesh>();
        animator = GetComponent<Animator>();
    }

    public void SetText(string text)
    {
        textMesh.text = text;
    }

	void Update () {
		
	}

    void OnMouseDown()
    {
        TogglePanel();
    }

    private void TogglePanel()
    {
        int idleState = Animator.StringToHash("InfoPanelIdle");
        int hiddenState = Animator.StringToHash("InfoPanelHidden");
        if (animator.GetCurrentAnimatorStateInfo(0).nameHash == idleState
            || animator.GetCurrentAnimatorStateInfo(0).nameHash == hiddenState) { 
            Debug.Log("InfoPanel is not in IDLE state, cant toggle");
            Debug.Log("It it: " + animator.GetCurrentAnimatorStateInfo(0).nameHash);
            return;
        }

        if (this.isVisible == true)
            animator.SetTrigger("InfoPanelShow");
        else
            animator.SetTrigger("InfoPanelHide");


        this.isVisible = !this.isVisible;
    }
}
