using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBounce : MonoBehaviour
{
    private Rigidbody2D ridgidbody;
    Vector3 lastVelocity;

    private void Awake()
    {
        ridgidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = ridgidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, col.contacts[0].normal);
            ridgidbody.velocity = direction * Mathf.Max(speed, 0f);
        }
    }
}
