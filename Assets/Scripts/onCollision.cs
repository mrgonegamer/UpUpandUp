using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator Fall(Rigidbody2D rigidbody2D)
    {
        //Makes platform fall
        yield return new WaitForSeconds(2f);
        //first method
        Vector3 movement = new Vector3(0.0f, -35.0f, 0.0f);
        rb.AddForce(movement * speed);
        //second method
        rb.velocity = transform.up * -speed;
    }
    void OnCollisionEnter2D(Collision2D collidedWithThis)
    {
        Debug.Log("collision detected");
        if (collidedWithThis.transform.name == "Player")
        {
            StartCoroutine(Fall(collidedWithThis.rigidbody));
        }
    }
}
