using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShooter : MonoBehaviour
{
    private Animator playerAnimator;
    private bool shouldPlayerFire;
    
    [SerializeField] 
    private GameObject waterBulletObject;
    [SerializeField]
    private static int playerInitialAmmo = 3;

    private int playerAmmo = 1;

    private GameObject waterBulletInstance;

    [SerializeField]
    private float firingCooldown = 1f;

    public Sprite waterBullet;
    public Image[] waterBullets;

    void Start()
    {
        shouldPlayerFire = true;
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            playerAnimator.SetBool("isShooting", ShootWaterBullet());
        }
        else
        {
            playerAnimator.SetBool("isShooting", false);
        }

        if (playerAmmo > 0)
        {
            for (int i = 0; i < playerAmmo; i++)
            {
                waterBullets[i].color = new Color(255, 255, 255, 1);
            }
            for (int i = playerAmmo; i < waterBullets.Length; i++)
            {
                waterBullets[i].color = new Color(255, 255, 255, 0);
            }
        }

        if (playerAmmo == 0)
        {
            foreach (var item in waterBullets)
            {
                item.color = new Color(255, 255, 255, 0);
            }
        }
    }

    public void AddAmmo(int amt)
    {
        this.playerAmmo = Mathf.Min(playerInitialAmmo, playerAmmo + amt);
    }

    public void UseAmmo(int amt)
    {
        this.playerAmmo = Mathf.Max(0, playerAmmo - amt);
    }

    bool ShootWaterBullet()
    {
        if (!shouldPlayerFire || playerAmmo == 0) return false;

        waterBulletInstance = 
            Instantiate(waterBulletObject, 
                        new Vector2(this.transform.position.x + 2, this.transform.position.y),
                        new Quaternion());

        waterBulletInstance.transform.localScale = Vector3.one;
        UseAmmo(1);

        StartCoroutine(StartFiringCooldown());
        return true;
    }

    IEnumerator StartFiringCooldown()
    {
        shouldPlayerFire = false;

        yield return new WaitForSeconds(firingCooldown);

        shouldPlayerFire = true;
    }
}
