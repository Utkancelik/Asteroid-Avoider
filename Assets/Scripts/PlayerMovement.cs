using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    /*
     * Handles the movement of player.
    */
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxForceMagnitude;



    private Camera mainCam;
    private Vector3 moveDir;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
    }
    private void Update()
    {   
        // check if I pressed on screen
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            // then find the where i click in screen coordinates
            Vector2 screenPos = Touchscreen.current.primaryTouch.position.ReadValue();
            //Convert it to world position
            Vector3 worldPos = mainCam.ScreenToWorldPoint(screenPos);
            // determine the movement direction
            moveDir = transform.position - worldPos;
            // we are making 2d game so we only need x,y position 
            moveDir.z = 0.0f;
            // we need movement direction not magnitude so we need to normalize it.
            moveDir.Normalize();
            // now we can apply force
            // but since it is a physics-based issue we need to do it in FixedUpdate
        }
        else
        {
            moveDir = Vector3.zero;
        }
    }
    private void FixedUpdate()
    {
        // if we dont press anything return
        if (moveDir == Vector3.zero) { return; }

        // otherwise means that we have a direction so we apply force
        rb.AddForce(moveDir * forceMagnitude, ForceMode.Force);
        // restrict the velocity of the rigidbody
        rb.velocity =  Vector3.ClampMagnitude(rb.velocity,maxForceMagnitude);
    }


}
