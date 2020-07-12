using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyShoot : MonoBehaviour
{
    public Transform shootPoint;

    public float shotDelay = 5;
    private float timeUntilShot;

    void Start()
    {
        timeUntilShot = shotDelay;
    }
    private void FixedUpdate()
    {
        timeUntilShot -= Time.fixedDeltaTime;
        if (timeUntilShot <= 0)
        {
            timeUntilShot = shotDelay;
            Shoot((float) Math.PI / 9);
            Shoot((float) -Math.PI / 9);
            Shoot((float) Math.PI / 18);
            Shoot((float) -Math.PI / 18);
        }
    }
    void Shoot(float offset)
    {
        GameObject bullet = ObjectPooling.Instance.SpawnFromPool("Bullet", shootPoint.position, shootPoint.rotation);
        bullet.transform.parent = GameObject.Find("ObjectPool/Active/Bullet").transform;

        Vector3 trajectory = Vector3.RotateTowards(shootPoint.up, shootPoint.right, offset, 0);

        //update with bullet speed
        bullet.GetComponent<Rigidbody2D>().AddForce(trajectory.normalized *  bullet.GetComponent<Bullet>().speed, ForceMode2D.Impulse);
    }
}
