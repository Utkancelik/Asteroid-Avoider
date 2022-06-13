using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // look if the item I collided with has playerHealth script
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        // if it has not then do nothing 
        if(playerHealth == null) { return; }
        // if it has it means that it is a player ship then call the function CRASH
        playerHealth.Crash();
    }
}
