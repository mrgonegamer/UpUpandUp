using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the movement
    [SerializeField] private float jumpHeight = .000075f; // Height of the jump
    public float groundCheckDistance = 0.1f; // Distance to check if the player is on the ground
    public LayerMask platformLayer; // Layer of the platforms

    private Rigidbody2D rb;
    private Collider2D coll;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f; // Add gravity to the Rigidbody2D component
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && IsTouchingPlatform())
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            Debug.Log("I jumped");
        }
    }

    void FixedUpdate()
    {
        // Horizontal movement input
        float horizontal = Input.GetAxis("Horizontal");

        // Move the player left or right
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }

    bool IsTouchingPlatform()
    {
        // Check if the player is touching any platform
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(platformLayer);
        return coll.IsTouching(contactFilter);
    }
}

