using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    // will be displayed when game end
    [SerializeField] private GameObject gameOverDisplay;
    // will be disabled so there wont be any spawning asteroids
    [SerializeField] private AsteroidSpawner asteroidSpawner;

    // when game ends this method called
    public void EndGame()
    {
        asteroidSpawner.enabled = false;

        gameOverDisplay.SetActive(true);
    }

    // method for Play Again button
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    // method for Return To Menu button
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
