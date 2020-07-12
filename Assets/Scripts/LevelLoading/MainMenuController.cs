using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public int bestKills;
    public float bestTime;

    public Text killText;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        LoadScores();
        string completetionTime = string.Format("{0:0}:{1:00}.{2:00}",
                    Mathf.Floor(bestTime / 60),//minutes
                    Mathf.Floor(bestTime) % 60,//seconds
                    Mathf.Floor((bestTime * 100) % 100));//miliseconds
        killText.text = "" + bestKills;
        timeText.text = completetionTime;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            LoadManager.Instance
                .LoadGame(SceneIndexes.SQUARE);
        }
    }

    void LoadScores()
    {
        if (PlayerPrefs.HasKey("HighScoreKills"))
        {
            bestKills = PlayerPrefs.GetInt("HighScoreKills");
            bestTime = PlayerPrefs.GetFloat("HighScoreTime");
        } else
        {
            bestKills = 0;
            bestTime = 0f;
        }
    }
}
