using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerLives;
    public float timer;
    public GameEvent playerDeath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage()
    {
        playerLives--;
        if (playerLives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        playerDeath.Raise();
        Debug.Log("GAME OVER");
    }
}
