using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public GameEvent enemyHit;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            if (transform.tag == "Anger")
            {
                AngerExplode explode = new AngerExplode();
                explode.MakeShrapnel(explode.KilledShrapnel, transform);
            }
            Die();
            enemyHit.Raise();
        }
    }

    private void Die()
    {
        ObjectPooling.Instance.ResetPoolObj(transform.tag, gameObject);
    }

}
