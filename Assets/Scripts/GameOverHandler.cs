using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverScoreText;
    // reference to score system script to get last score when game ends
    [SerializeField] private ScoreSystem scoreSystem;
    // will be displayed when game end
    [SerializeField] private GameObject gameOverDisplay;
    // will be disabled so there wont be any spawning asteroids
    [SerializeField] private AsteroidSpawner asteroidSpawner;

    // when game ends this method called
    public void EndGame()
    {
        // no more spawning asteroids when game ends
        asteroidSpawner.enabled = false;

        // game over screen is active
        gameOverDisplay.SetActive(true);

        // score display
        int lastScore = scoreSystem.StopScore();
        gameOverScoreText.text = $"Your Score: {lastScore}";
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
