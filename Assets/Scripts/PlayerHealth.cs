using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameOverHandler gameOverHandler;
    // Call it when player crash
    public void Crash()
    {
        // deactivate the player obj. then you can activate it by watching ad.
        gameObject.SetActive(false);

        gameOverHandler.EndGame();
    }
}
