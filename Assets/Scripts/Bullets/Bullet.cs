using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    private Rigidbody2D rb;

    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(9.8f * 25f, 9.8f * 25f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
