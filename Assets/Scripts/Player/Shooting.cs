﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootPoint;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = ObjectPooling.Instance.SpawnFromPool("Bullet", shootPoint.position, shootPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(shootPoint.up * 20f, ForceMode2D.Impulse);
    }
}