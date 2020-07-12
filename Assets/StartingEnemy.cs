using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingEnemy : MonoBehaviour
{
    public GameEvent gameStart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Die();
            gameStart.Raise();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
