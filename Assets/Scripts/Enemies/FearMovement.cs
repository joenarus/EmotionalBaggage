﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearMovement : MonoBehaviour
{
    public float moveSpeed = 1f;

    public Rigidbody2D rb;
    private Rigidbody2D player;

    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        direction = rb.position - player.position;
        direction.Normalize();

        rb.MovePosition(rb.position - moveSpeed * Time.fixedDeltaTime * direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    // Update is called once per frame
    void Update()
    {
    }
}