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

    private Rigidbody2D player;

    private float nextFearUpdate;
    private float nextAngerUpdate;
    private float nextPanicUpdate;
    private float nextAnxietyUpdate;

    public float nextFearInterval = 1;
    public float nextAngerInterval = 10;
    public float nextPanicInterval = 20;
    public float nextAnxietyInterval = 20;

    public bool timerActive;
    public int finalKills;

    public int oldHighScoreKills;
    public float oldHighScoreTime;

    public Texture2D cursor;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        if (PlayerPrefs.HasKey("HighScoreKills"))
        {
            oldHighScoreKills = PlayerPrefs.GetInt("HighScoreKills");
            oldHighScoreTime = PlayerPrefs.GetFloat("HighScoreTime");
        }
        else
        {
            oldHighScoreKills = 0;
            oldHighScoreTime = 0f;
        }
        finalKills = 0;
        playerTime.value = 0;
        timerActive = false;
        playerLives.value = playerLives.InitialValue;
        playerKills.value = playerKills.InitialValue;
    }

    public void GameStart()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        timerActive = true;
        StartTime = Time.time;
        nextFearUpdate = Mathf.FloorToInt(Time.time) + nextFearInterval;
        nextAngerUpdate = Mathf.FloorToInt(Time.time) + nextAngerInterval;
        nextPanicUpdate = Mathf.FloorToInt(Time.time) + nextPanicInterval;
        nextAnxietyUpdate = Mathf.FloorToInt(Time.time) + nextAnxietyInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            playerTime.value = Time.time - StartTime;


            if (Time.time >= nextFearUpdate)
            {
                nextFearUpdate = Mathf.FloorToInt(Time.time) + nextFearInterval;
                UpdateFear(DetermineSpawn());
            }
            if (Time.time >= nextAngerUpdate)
            {
                nextAngerUpdate = Mathf.FloorToInt(Time.time) + nextAngerInterval;
                UpdateAnger(DetermineSpawn());
            }
            if (Time.time >= nextPanicUpdate)
            {
                nextPanicUpdate = Mathf.FloorToInt(Time.time) + nextPanicInterval;
                UpdatePanic(DetermineSpawn());
            }
            if (Time.time >= nextAnxietyUpdate)
            {
                nextAnxietyUpdate = Mathf.FloorToInt(Time.time) + nextAnxietyInterval;
                UpdateAnxiety(DetermineSpawn());
            }
        }
    }



    public void takeDamage()
    {
        if (playerLives.value <= 0)
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
        if (playerTime.value > oldHighScoreTime)
        {
            PlayerPrefs.SetFloat("HighScoreTime", playerTime.value);
        }
        playerDeath.Raise();

        Debug.Log("GAME OVER");
    }

    public void UpdateFear(Vector3 pos)
    {
        GameObject fear = ObjectPooling.Instance.SpawnFromPool("Fear", pos, Quaternion.identity);
        fear.transform.parent = GameObject.Find("ObjectPool/Active/Fear").transform;

    }
    public void UpdateAnger(Vector3 pos)
    {
        GameObject anger = ObjectPooling.Instance.SpawnFromPool("Anger", pos, Quaternion.identity);
        anger.transform.parent = GameObject.Find("ObjectPool/Active/Anger").transform;
    }
    public void UpdatePanic(Vector3 pos)
    {
        GameObject panic = ObjectPooling.Instance.SpawnFromPool("Panic", pos, Quaternion.identity);
        panic.transform.parent = GameObject.Find("ObjectPool/Active/Panic").transform;
    }
    public void UpdateAnxiety(Vector3 pos)
    {
        GameObject anxiety = ObjectPooling.Instance.SpawnFromPool("Anxiety", pos, Quaternion.identity);
        anxiety.transform.parent = GameObject.Find("ObjectPool/Active/Anxiety").transform;
    }

    private Vector3 DetermineSpawn()
    {
        Vector2 spawn;
        do
        {
            spawn = new Vector2(UnityEngine.Random.Range(-8.5f, 8.5f), UnityEngine.Random.Range(-8.5f, 8.5f));
        } while (Vector2.Distance(spawn, player.position) < 2.5);

        return spawn;
    }
}
