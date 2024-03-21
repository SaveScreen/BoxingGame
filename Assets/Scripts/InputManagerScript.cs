using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerScript : MonoBehaviour
{
    public GameObject player;
    private PlayerScript playerScript;
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
        playerInput = GetComponent<PlayerInput>();

    }

    public void OnDodge(InputAction.CallbackContext context) {
        if (context.started) {
            playerScript.Dodge(context.ReadValue<float>());
        }
        if (context.canceled) {
            playerScript.ResetDodge();
        }
    }

    public void OnLeftPunch(InputAction.CallbackContext context) {
        if (playerScript.isBlocking == false) {
            if (context.started) {
                playerScript.Punch(true);
            }
            if (context.canceled) {
                playerScript.ResetPunch(true); 
            }
        }
        else {
           if (context.started) {
                playerScript.Punch(true);
            }
            if (context.canceled) {
                playerScript.ResetPunch(true);
            } 
        }
        
    }

    public void OnRightPunch(InputAction.CallbackContext context) {
        if (context.started) {
            if (!playerScript.isRightPunching) {
                playerScript.Punch(false);
            }
        }
        if (context.canceled) {
            if (playerScript.isRightPunching) {
                playerScript.ResetPunch(false);
            }
        }
    }

    public void OnDuck(InputAction.CallbackContext context) {
        if (context.started) {
            playerScript.Duck();
        }
        if (context.canceled) {
            playerScript.ResetDuck();
        }
    }

    public void OnBlock(InputAction.CallbackContext context) {
        if (context.started) {
            playerScript.Block();
        }
        if (context.canceled) {
            playerScript.ResetBlock();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
