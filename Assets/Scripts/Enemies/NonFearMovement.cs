using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonFearMovement : MonoBehaviour, IPooledObject
{
    public float moveSpeed = 1f;
    private float timeUntilChange;
    public float movementTime = 5;

    public Rigidbody2D rb;
    private Rigidbody2D player;
    private Vector2 direction;
    private Random rand = new Random();

    public void OnObjectSpawn()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        direction = new Vector2(Random.Range(-180f, 180f), Random.Range(-180f, 180f));
        direction.Normalize();
        timeUntilChange = movementTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        direction = new Vector2(Random.Range(-180f, 180f), Random.Range(-180f, 180f));
        direction.Normalize();
        timeUntilChange = movementTime;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * direction);

        timeUntilChange -= Time.fixedDeltaTime;
        if (timeUntilChange <= 0)
        {
            timeUntilChange = movementTime;
            direction = new Vector2(Random.Range(-180f,180f), Random.Range(-180f,180f));
            direction.Normalize();
        }

        Vector2 lookDir = player.position - rb.position;
        lookDir.Normalize();
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        direction = Vector3.Reflect(direction.normalized, col.contacts[0].normal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
