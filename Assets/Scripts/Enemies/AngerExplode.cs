using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using UnityEngine;

public class AngerExplode : MonoBehaviour
{
    public GameEvent enemyHit;
    public Transform explosionCenter;
    public float ExplosionDelay = 5;
    public int selfDestuctShrapnel = 5;
    public int KilledShrapnel = 3;

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

        Debug.Log("Kaboom");

        MakeShrapnel(selfDestuctShrapnel, explosionCenter);

        ObjectPooling.Instance.ResetPoolObj(transform.tag, gameObject);
        enemyHit.Raise();
    }

    public void MakeShrapnel(int shrapnelNum, Transform explosionCenter)
    {
        for (int i = 0; i < shrapnelNum; i++)
        {
            GameObject bullet = ObjectPooling.Instance.SpawnFromPool("Bullet", explosionCenter.position, Quaternion.identity);
            bullet.transform.parent = GameObject.Find("ObjectPool/Active/Bullet").transform;
            bullet.GetComponent<Rigidbody2D>().AddForce(
                new Vector3(UnityEngine.Random.Range(-100, 100), 
                UnityEngine.Random.Range(-100, 100), 0).normalized * bullet.GetComponent<Bullet>().speed, 
                ForceMode2D.Impulse);
        }
    }


}
