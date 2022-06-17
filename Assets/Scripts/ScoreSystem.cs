using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private int scoreMultiplier;
    [SerializeField] private TMP_Text scoreText;


    private float score = 0;
    private bool scoreIncrease = true;

    private void Update()
    {
        if (!scoreIncrease) { return; }

        // score increases
        score += Time.deltaTime * scoreMultiplier;

        // text the score every frame
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public int StopScore()
    {
        scoreIncrease = false;

        scoreText.text = string.Empty;

        return Mathf.FloorToInt(score);
    }
}
