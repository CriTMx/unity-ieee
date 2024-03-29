using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlayerCollision : MonoBehaviour
{
    /*[SerializeField]
    private GameObject player;*/

    public int gemScoreBonus = 1000;
    public int healthScoreBonus = 100;
    public int ammoScoreBonus = 300;
    public int enemyKillScoreBonus = 500;

    public int enemyScorePenalty = 1000;

    private CharacterHealth playerHP;
    private CharacterShooter playerShooter;
    private PlayerScoreController playerScore;

    void Start()
    {
        /*playerHP = player.GetComponent<CharacterHealth>();
        playerShooter = player.GetComponent<CharacterShooter>();
        playerScore = player.GetComponent<PlayerScoreController>(); */
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Bounds"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            playerHP = collision.GetComponent<CharacterHealth>();
            playerShooter = collision.GetComponent<CharacterShooter>();
            playerScore = collision.GetComponent<PlayerScoreController>();

            if (this.gameObject.CompareTag("PickupHealth"))
            {
                playerHP.ChangePlayerHealth(1);
                playerScore.AddScore(healthScoreBonus);
            }

            if (this.gameObject.CompareTag("PickupAmmo"))
            {
                playerShooter.AddAmmo(3);
                playerScore.AddScore(ammoScoreBonus);
            }

            if (this.gameObject.CompareTag("PickupGem"))
            {
                playerScore.AddScore(gemScoreBonus);
            }

            Destroy(this.gameObject);
        }

        if (this.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerHP = collision.GetComponent<CharacterHealth>();
                playerShooter = collision.GetComponent<CharacterShooter>();
                playerScore = collision.GetComponent<PlayerScoreController>();

                playerHP.ChangePlayerHealth(-1);
                playerScore.SubtractScore(enemyScorePenalty);
            }
/*            if (collision.gameObject.CompareTag("PlayerProjectile"))
            {
                playerScore.AddScore(enemyKillScoreBonus);
                Destroy(this.gameObject);
            }*/
        }
    }
}
