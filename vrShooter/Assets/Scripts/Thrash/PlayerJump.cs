using System;
using UnityEngine;
using Valve.VR;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    
    private int jumpCount = 2;
    private const int MaxJumpCount = 2;
    
    public SteamVR_Action_Boolean triggerDown;
    public SteamVR_Action_Boolean trackpadTouchAction;
    public SteamVR_Action_Boolean trackpadClickAction;
    public SteamVR_Action_Vector2 trackpadVectorAction;
    public SteamVR_Input_Sources handType;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();//GetComponentInParent<Rigidbody>();
        if (playerRigidbody == null)  Debug.LogError("No rigidbody! PlayerJump.cs error");
    }

    void Update()
    {
        if (triggerDown.stateDown)
        { 
            Debug.Log("shootaction");
        }
        if (trackpadTouchAction.stateDown)
        { 
            Vector2 touchpadVector = trackpadVectorAction.GetAxis(handType);
            Debug.Log(touchpadVector);
        }
        if (trackpadClickAction.stateDown)
        {
            Vector2 touchpadVector = trackpadVectorAction.GetAxis(handType);
            Debug.Log("trackpadClickAction");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("UpArrow");
            Jump(Vector3.forward * 500 + Vector3.up * 500);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("DownArrow");
            Jump(Vector3.back * 500 + Vector3.up * 500);

        }
    }

    private void Jump(Vector3 direction)
    {
        if (jumpCount > 0)
        {
            jumpCount--;
            playerRigidbody.AddForce(direction);
        }
    }

    public void resetJumpCount()
    {
        jumpCount = MaxJumpCount;
    }
}