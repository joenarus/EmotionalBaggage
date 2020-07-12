using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            LoadManager.Instance
                .LoadGame(SceneIndexes.SQUARE);
            gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadManager.Instance.LoadTitle();
            gameObject.SetActive(false);
        }
    }

    
}
