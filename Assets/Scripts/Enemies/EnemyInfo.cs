using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public GameEvent enemyHit;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Die();
            enemyHit.Raise();
        }
    }

    private void Die()
    {
        ObjectPooling.Instance.ResetPoolObj(transform.tag, gameObject);
    }

}
