using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public IntVariable playerLives;
    public float StartTime;
    public GameEvent playerDeath;
    public Text lifeText;

    public Image Life1;
    public Image Life2;
    public Image Life3;

    public Sprite LostLife;


    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
        playerLives.value = playerLives.InitialValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        if(playerLives.value <= 0)
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
