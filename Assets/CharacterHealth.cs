using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField]
    private static int playerInitialHP = 3;

    [SerializeField]
    private GameObject GameOverScreen;

    public int playerHP = playerInitialHP;
    public bool isPlayerAlive = true;

    public Sprite heart;
    public Image[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);
    }

    void Update()
    {
        if (playerHP == 0)
        {
            GameOverScreen.SetActive(true);
            Debug.Log("Player died!");
            isPlayerAlive = false;
            Destroy(this.gameObject);
        }

        if (playerHP > 0)
        {
            for (int i = 0; i < playerHP; i++)
            {
                hearts[i].color = new Color(255, 255, 255, 1);
            }
            for (int i = playerHP; i < hearts.Length; i++)
            {
                hearts[i].color = new Color(255, 255, 255, 0);
            }
        }

        if (playerHP == 0)
        {
            foreach (var item in hearts)
            {
                item.color = new Color(255, 255, 255, 0);
            }
        }
    }

    public void ChangePlayerHealth(int amt)
    {
        if (playerHP + amt > playerInitialHP) playerHP = playerInitialHP;
        else if (playerHP + amt < 0) playerHP = 0;
        else playerHP += amt;
        Debug.Log("player current HP: " + playerHP);
    }

    public void FillHealth()
    {
        playerHP = playerInitialHP;
    }

    public void KillPlayer()
    {
        playerHP = 0;
    }


}
