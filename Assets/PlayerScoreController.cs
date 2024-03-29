using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreController : MonoBehaviour
{
    public long Score = 0;
    private bool shouldScoreChange = true;
    private CharacterHealth playerHP;

    [SerializeField]
    private long maxScore = 9999999;

    [SerializeField]
    private TMP_Text scoreText;

    void Start()
    {
        playerHP = GetComponent<CharacterHealth>();
        scoreText.SetText(Score.ToString());
        StartCoroutine(PlayerAliveScoreIncrementer());
    }

    void Update()
    {
        scoreText.SetText(Score.ToString());
    }

    public void AddScore(int amt)
    {
        if (Score != maxScore && shouldScoreChange) Score += amt;
    }

    public void SubtractScore(int amt)
    {
        if (Score != -maxScore && shouldScoreChange) Score -= amt;
    }

    public long FreezeScore()
    {
        shouldScoreChange = false;
        return Score;
    }

    IEnumerator PlayerAliveScoreIncrementer()
    {
        while (playerHP.isPlayerAlive && shouldScoreChange)
        {
            yield return new WaitForSeconds(1);
            Score += 10;
        }
    }
}
