using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public GameEvent playerHit;
    public IntVariable playerLives;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet" || collision.tag == "Fear" || collision.tag == "Panic" || collision.tag == "Anger")
        {
            Debug.Log(collision.transform.name);
            playerLives.value--;
            playerHit.Raise();
        }
    }
}
