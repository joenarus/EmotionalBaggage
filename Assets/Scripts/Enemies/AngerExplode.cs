using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerExplode : MonoBehaviour
{
    public GameEvent enemyHit;
    public float ExplosionDelay = 5;

    private void FixedUpdate()
    {
        ExplosionDelay -= Time.fixedDeltaTime;
        if (ExplosionDelay <= 0)
        {
            Explode();
        }
    }
    void Explode()
    {
        Destroy(gameObject);
        enemyHit.Raise();
    }


}
