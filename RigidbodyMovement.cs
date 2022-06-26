using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    /*
     * Rigidbody is used when it is necessary to use in-game physics, such as gravity and collision, especially if very fast collision detection is needed.
     * An object with a rigidbody has a "physical body", that is, two objects with a rigidbody do not occupy the same space.
     */

    private Rigidbody2D rig;
    [SerializeField] float Speed = 5f;
    public float JumpForce = 5f;

    bool isJumping;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);
        Jump();
        //LimitedJump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // It is necessary to reset the speed of the player in order to do the double jump.
            rig.velocity = new Vector2(0,0);
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    void LimitedJump()
    {
        //With a simple boolean and colission functions it is possible to limit the player's jump.
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rig.velocity = new Vector2(0, 0);
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Comparing the name of the object
        if (collision.gameObject.name == "Ground")
        {
            isJumping = false;
        }
        /* Comparing using comapare tag
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Tag");
        }
        */
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isJumping = true;
        }
    }
}
