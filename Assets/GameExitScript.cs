using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitScript : MonoBehaviour
{
    public void exitButton()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
