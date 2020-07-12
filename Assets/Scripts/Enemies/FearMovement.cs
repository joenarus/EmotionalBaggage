using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearMovement : MonoBehaviour, IPooledObject
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
        direction = player.position - rb.position;
        direction.Normalize();

        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * direction);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnObjectSpawn()
    {
        gameObject.GetComponentInChildren<Animator>().SetTrigger("Spawn");
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    public void OnObjectDespawn()
    {
        if (gameObject.active) {
             StartCoroutine(Despawn());
        }
    }



    IEnumerator Despawn()
    {
        gameObject.GetComponentInChildren<Animator>().SetTrigger("Die");
        yield return new WaitForSeconds(.4f);
        GameObject objectPool = GameObject.Find("ObjectPool");
        transform.parent = objectPool.transform.Find("Inactive/" + tag);
        transform.rotation = objectPool.transform.rotation;
        transform.position = objectPool.transform.position;

        gameObject.SetActive(false);
    }
}
