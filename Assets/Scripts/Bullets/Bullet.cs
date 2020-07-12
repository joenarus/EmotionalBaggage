using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    private Rigidbody2D rb;
    public float speed;

    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(speed, speed));
    }

    public void OnObjectDespawn()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
