using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public IntVariable playerLives;
    public IntVariable playerKills;
    public FloatVariable playerTime;
    public float StartTime;
    public GameEvent playerDeath;

    private float nextFearUpdate;
    private float nextAngerUpdate;
    private float nextPanicUpdate;

    public float nextFearInterval = 1;
    public float nextAngerInterval = 10;
    public float nextPanicInterval = 20;

    public bool timerActive;
    public int finalKills;

    public int oldHighScoreKills;
    public float oldHighScoreTime;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScoreKills"))
        {
            oldHighScoreKills = PlayerPrefs.GetInt("HighScoreKills");
            oldHighScoreTime = PlayerPrefs.GetFloat("HighScoreTime");
        } else
        {
            oldHighScoreKills = 0;
            oldHighScoreTime = 0f;
        }
        finalKills = 0;
        playerTime.value = 0;
        timerActive = false;
        GameStart();
    }

    void GameStart()
    {
        timerActive = true;
        StartTime = Time.time;
        playerLives.value = playerLives.InitialValue;
        playerKills.value = playerKills.InitialValue;
        nextFearUpdate = Mathf.FloorToInt(Time.time) + nextFearInterval;
        nextAngerUpdate = Mathf.FloorToInt(Time.time) + nextAngerInterval;
        nextPanicUpdate = Mathf.FloorToInt(Time.time) + nextPanicInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive)
        {
            playerTime.value = Time.time - StartTime;
        }
        
        if (Time.time >= nextFearUpdate)
        {
            nextFearUpdate = Mathf.FloorToInt(Time.time) + nextFearInterval;
            UpdateFear();
        }
        if (Time.time >= nextAngerUpdate)
        {
            nextAngerUpdate = Mathf.FloorToInt(Time.time) + nextAngerInterval;
            UpdateAnger();
        }
        if (Time.time >= nextPanicUpdate)
        {
            nextPanicUpdate = Mathf.FloorToInt(Time.time) + nextPanicInterval;
            UpdatePanic();
        }
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
        finalKills = playerKills.value;
        timerActive = false;

        if (finalKills > oldHighScoreKills)
        {
            PlayerPrefs.SetInt("HighScoreKills", finalKills);
        }
        if(playerTime.value > oldHighScoreTime)
        {
            PlayerPrefs.SetFloat("HighScoreTime", playerTime.value);
        }
        playerDeath.Raise();
        
        Debug.Log("GAME OVER");
    }

    public void UpdateFear()
    {
        GameObject fear = ObjectPooling.Instance.SpawnFromPool("Fear", new Vector3(0,0,0),Quaternion.identity);
        fear.transform.parent = GameObject.Find("ObjectPool/Active/Fear").transform;

    }
    public void UpdateAnger()
    {
        GameObject anger = ObjectPooling.Instance.SpawnFromPool("Anger", new Vector3(1, 0, 0), Quaternion.identity);
        anger.transform.parent = GameObject.Find("ObjectPool/Active/Anger").transform;
    }
    public void UpdatePanic()
    {
        GameObject panic = ObjectPooling.Instance.SpawnFromPool("Panic", new Vector3(2, 0, 0), Quaternion.identity);
        panic.transform.parent = GameObject.Find("ObjectPool/Active/Panic").transform;

    }
}
