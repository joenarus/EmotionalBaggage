﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUIController : MonoBehaviour
{
    public GameManager TheManager;
    public IntVariable playerLives;
    public FloatVariable playerTime;
    public Text timerText;
    public Text lifeText;

    public Image Life1;
    public Image Life2;
    public Image Life3;

    public Sprite LostLife;

    public GameObject damageScreen;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string completetionTime = string.Format("{0:0}:{1:00}.{2:00}",
                     Mathf.Floor(playerTime.value / 60),//minutes
                     Mathf.Floor(playerTime.value) % 60,//seconds
                     Mathf.Floor((playerTime.value * 100) % 100));//miliseconds

        timerText.text = completetionTime;
    }

    public void takeDamage()
    {
        switch (playerLives.value)
        {
            case 0:
                Life1.sprite = LostLife;
                break;
            case 1:
                Life2.sprite = LostLife;
                break;
            case 2:
                Life3.sprite = LostLife;
                break;
            default:
                break;
        }

        lifeText.text = "Lives : " + (playerLives.value);

        StartCoroutine(DisplayDamage(.2f));
    }

    IEnumerator DisplayDamage(float seconds)
    {
        damageScreen.SetActive(true);
        yield return new WaitForSeconds(seconds);
        damageScreen.SetActive(false);
    }
}
