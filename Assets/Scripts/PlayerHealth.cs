using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Call it when player crash
    public void Crash()
    {
        // deactivate the player obj. then you can activate it by watching ad.
        gameObject.SetActive(false);
    }
}
