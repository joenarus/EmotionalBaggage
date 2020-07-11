using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicShoot : MonoBehaviour
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
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = ObjectPooling.Instance.SpawnFromPool("Bullet", shootPoint.position, shootPoint.rotation);
        bullet.transform.parent = GameObject.Find("ObjectPool/Active/Bullet").transform;
        bullet.GetComponent<Rigidbody2D>().AddForce(shootPoint.up * 20f, ForceMode2D.Impulse);
    }
}
