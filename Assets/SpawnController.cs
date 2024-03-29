using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject EnemyObj;
    [SerializeField]
    private GameObject PickupHealthObj;
    [SerializeField]
    private GameObject PickupAmmoObj;
    [SerializeField]
    private GameObject PickupGemObj;

    private PlayerScoreController playerScore;

    private static float enemyInitialSpawnCooldown = 2f;
    [SerializeField]
    private float enemySpawnCooldown = enemyInitialSpawnCooldown;

    private static float pickupInitialSpawnCooldown = 10f;
    [SerializeField]
    private float pickupSpawnCooldown = pickupInitialSpawnCooldown;

    private bool shouldEnemySpawn = true;
    private bool shouldPickupSpawn = true;
    private bool masterSpawnControlEnabled = true;

    private int pickupSpawner;
    private float objectSpawnX, enemySpawnY, pickupSpawnY;

    void Start()
    {
        playerScore = Player.GetComponent<PlayerScoreController>();
        objectSpawnX = transform.position.x - 1.5f;
    }

    void Update()
    {
        if (masterSpawnControlEnabled)
        {
            pickupSpawner = Random.Range(1, 100);
            enemySpawnY = Random.Range(-6.5f, 8f);
            pickupSpawnY = Random.Range(-6.5f, 8f);

            if (enemySpawnY == pickupSpawnY)
            {
                pickupSpawnY = Mathf.Max(-6.5f, -enemySpawnY);
            }

            if (shouldEnemySpawn)
            {
                Instantiate(EnemyObj, new Vector2(objectSpawnX, enemySpawnY), new Quaternion());

                StartCoroutine(
                    EnemySpawnCooldown(
                        Mathf.Max(
                            enemySpawnCooldown - ((playerScore.Score / 1000) * 0.4f)
                            , 0.2f)
                        )
                    );
            }

            if (shouldPickupSpawn)
            {
                if (pickupSpawner <= 25)
                {
                    Instantiate(PickupHealthObj, new Vector2(objectSpawnX, pickupSpawnY), new Quaternion());
                    StartCoroutine(PickupSpawnCooldown(pickupSpawnCooldown));
                }
                if (pickupSpawner > 25 && pickupSpawner <= 50)
                {
                    Instantiate(PickupAmmoObj, new Vector2(objectSpawnX, pickupSpawnY), new Quaternion());
                    StartCoroutine(PickupSpawnCooldown(pickupSpawnCooldown));
                }
                if (pickupSpawner > 50 && pickupSpawner <= 100)
                {
                    Instantiate(PickupGemObj, new Vector2(objectSpawnX, pickupSpawnY), new Quaternion());
                    StartCoroutine(PickupSpawnCooldown(pickupSpawnCooldown));
                }
            }

            // Formula to increase game difficulty with time
            // Mathf.Max(enemySpawnCooldown - ((playerScore.Score / 1000) * 0.4f), 0.3f);
        }

    }

    public void FreezeAllSpawns()
    {
        masterSpawnControlEnabled = false;
    }

    private IEnumerator EnemySpawnCooldown(float seconds)
    {
        shouldEnemySpawn = false;
        yield return new WaitForSeconds(seconds);
        shouldEnemySpawn = true;
    }

    private IEnumerator PickupSpawnCooldown(float seconds)
    {
        shouldPickupSpawn = false;
        yield return new WaitForSeconds(seconds);
        shouldPickupSpawn = true;
    }
}
