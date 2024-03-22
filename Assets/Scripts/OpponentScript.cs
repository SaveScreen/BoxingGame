using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentScript : MonoBehaviour
{
    public GameObject player;
    private Animator playeranimator;
    private Vector3 startingposition;
    private bool attacking;
    private Animator animator;
    public float health;
    [HideInInspector] public bool attacked;
    [SerializeField] private GameObject basemodel;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playeranimator = player.GetComponentInChildren<Animator>();

        startingposition = basemodel.transform.position;
        attacked = false;
    }

    public void Attacked(bool leftSide) {
        if (leftSide) {
            animator.SetTrigger("Hit Left");
        }
        else {
            animator.SetTrigger("Hit Right");
        }
        //playeranimator.SetBool("OpponentReeling",true);
        attacked = true;
        StartCoroutine(EarlyTriggerReset(leftSide));
    }

    void SubtractHealth(float healthtosubtract) {
        health -= healthtosubtract;
    }

    void AddHealth(float healthtoadd) {
        health += healthtoadd;
    }

    // Update is called once per frame
    void Update()
    {
        if (attacked == true) {
            playeranimator.SetBool("OpponentReeling",true);
            attacked = false;
        }
        if (playeranimator.GetBool("OpponentReeling")) {
            AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateinfo.IsName("Idle")) {
                playeranimator.SetBool("OpponentReeling",false);
            }
        }
    }

    IEnumerator EarlyTriggerReset(bool leftside) {
        yield return new WaitForSeconds(0.1f);
        if (leftside) {
            animator.ResetTrigger("Hit Left");
        }
        else {
            animator.ResetTrigger("Hit Right");
        }
        basemodel.transform.position = startingposition;
        
    }
}
