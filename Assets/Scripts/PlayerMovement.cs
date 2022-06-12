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
    [SerializeField] private float rotationSpeed;





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
        DetermineMovementDirection();

        KeepPlayerOnScreen();

        RotateTowardsVelocityDirection();
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

    #region Handles the determining the movement direction
    private void DetermineMovementDirection()
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
    #endregion


    #region This function makes our game to be sure about our player doesnt go off screen.
    private void KeepPlayerOnScreen()
    {
        // since we cannot change the transform.position directly we are copy it to the newPos variable.
        Vector3 newPos = transform.position;
        // we are checking if the player go off screen by VIEWPORT
        // because we want this code to work in all devices so we cannot measure the manually.
        // VIEWPORT helps us to determine all devices' screen size (x and y)
        Vector3 viewportPos = mainCam.WorldToViewportPoint(transform.position);

        // if we went off to the right of the screen
        if (viewportPos.x > 1)
        {
            // then teleport the plyer the left side which means multiplied by (-) 
            newPos.x = -newPos.x + 0.1f;
        }
        // if we went off to the left of the screen
        else if (viewportPos.x < 0)
        {
            // then teleport the plyer the right side which means multiplied by (-) 
            newPos.x = -newPos.x - 0.1f;
        }
        // if we went off to the up of the screen
        if (viewportPos.y > 1)
        {
            // then teleport the plyer the down side which means multiplied by (-) 
            newPos.y = -newPos.y + 0.1f;
        }
        // if we went off to the down of the screen
        else if (viewportPos.y < 0)
        {
            // then teleport the plyer the up side which means multiplied by (-)
            newPos.y = -newPos.y - 0.1f; //the 0.1f part is because we want to make a little bit tp effect actually.
        }
        // after all conditions now we can assign manipulated position newPos to us position
        transform.position = newPos;
    }
    #endregion


    #region Handles the rotation of the ship 
    private void RotateTowardsVelocityDirection()
    {
        if(rb.velocity == Vector3.zero) { return; }

        Quaternion targetRotation = Quaternion.LookRotation(rb.velocity, Vector3.back);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    #endregion


}
