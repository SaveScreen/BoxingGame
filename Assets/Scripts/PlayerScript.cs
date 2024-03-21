using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Animator animator;
    public int animationState; //1 for dodging, 2 for punching
    [HideInInspector] public bool isPunching;
    [HideInInspector] public bool isLeftDodging;
    [HideInInspector] public bool isRightDodging;
    [HideInInspector] public bool isLeftPunching;
    [HideInInspector] public bool isRightPunching;
    [HideInInspector] public bool isBlocking;
    private bool isTransitioning;
    private bool waitUntilTransitioningisDone;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        isPunching = false;
        isLeftDodging = false;
        isRightDodging = false;
        isLeftPunching = false;
        isRightPunching = false;
        isBlocking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dodge(float direction) {
        animator.SetFloat("Dodge",direction);
        if (direction < 0) {
            isLeftDodging = true;
            isRightDodging = false;
        }
        else if (direction > 0) {
            isLeftDodging = false;
            isRightDodging = true;
        }
        else {
            isLeftDodging = false;
            isRightDodging = false;
        }
        animationState = 1;
    }

    public void ResetDodge() {
        animator.SetFloat("Dodge", 0);
    }

    public void Punch(bool leftpunch) {
        if (leftpunch) {
            animator.SetInteger("Punch",1);
            isLeftPunching = true;
            isRightPunching = false;
            animationState = 2;
        }
        else {
            animator.SetInteger("Punch",2);
            isRightPunching = true;
            isLeftPunching = false;
            animationState = 2;
        }
    }

    public void Jab(bool leftpunch) {
        if (leftpunch) {
            animator.SetInteger("Punch",1);
            isLeftPunching = true;
            isRightPunching = false;
            animationState = 2;
        }
        else {
            animator.SetInteger("Punch",2);
            isRightPunching = true;
            isLeftPunching = false;
            animationState = 2;
        }
    }

    public void ResetPunch(bool leftPunch) {
        if (leftPunch) {
            isLeftPunching = false;
        }
        else {
            isRightPunching = false;
        }
        animator.SetInteger("Punch", 0);
        animationState = 0;
        
    }

    public void ResetJab(bool leftpunch) {
        if (leftpunch) {
            isLeftPunching = false;
        }
        else {
            isRightPunching = false;
        }
        animator.SetInteger("Punch", 0);
        animationState = 0;
    }

    public void Duck() {
        animator.SetBool("Duck", true);
    }

    public void ResetDuck() {
        animator.SetBool("Duck", false);
    }

    public void Block() {
        animator.SetBool("Block",true);
        isBlocking = true;
    }

    public void ResetBlock() {
        animator.SetBool("Block",false);
        isBlocking = false;
    }

}
