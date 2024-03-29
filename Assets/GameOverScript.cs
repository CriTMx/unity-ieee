using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject spawnZone;
    [SerializeField]
    private TMP_Text finalScoreDisplay;

    private PlayerScoreController scoreController;
    private CharacterHealth playerHP;
    private SpawnController spawnController;

    private long finalScore;
    private bool isGameRunning = true;

    void Start()
    {
        scoreController = player.GetComponent<PlayerScoreController>();
        playerHP = player.GetComponent<CharacterHealth>();
        spawnController = spawnZone.GetComponent<SpawnController>();
        Debug.Log(this.enabled);
    }

    void Update()
    {
        if (!playerHP.isPlayerAlive && isGameRunning)
        {
            Debug.Log("here?");
            finalScore = scoreController.FreezeScore();
            finalScoreDisplay.SetText(finalScore.ToString());
            spawnController.FreezeAllSpawns();
            isGameRunning = false;
        }
    }
}
