using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    /*
     * Handles the movement of player.
    */
    private Camera mainCam;
    private void Start()
    {
        mainCam = Camera.main;
    }
    private void Update()
    {   
        // check if I pressed on screen
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            // then find the where i click.
            Vector2 screenPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Debug.Log($"Screen Position : {screenPos}");
            //Convert it to world position
            Vector3 worldPos = mainCam.ScreenToWorldPoint(screenPos);
            Debug.Log($"World Position : {worldPos}");


        }
    }


}
