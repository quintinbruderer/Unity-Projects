using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class player : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    Transform trans;
    public int topSpeed;
    public int jump;
    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        playerMovement(horizontal);
        playerFlip();
        
    }

    private void playerMovement(float horizontal)
    {
        if (rb2d.velocity.y > 0.1f || rb2d.velocity.y < -0.2f) {
            rb2d.velocity = new Vector2(horizontal * topSpeed * 0.5f, rb2d.velocity.y);
            anim.SetTrigger("idle"); // change this so no running
            // jumping true stuff
        }
        else
        {
            rb2d.velocity = new Vector2(horizontal * topSpeed, rb2d.velocity.y);

            if (rb2d.velocity.x > 0.5f || rb2d.velocity.x < -0.5f) // and not jumping
            {
                anim.SetTrigger("run");
            }
            else
            {
                anim.SetTrigger("idle");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
    }

    private void playerFlip()
    {
        if (rb2d.velocity.x > 0.5f && !facingRight || rb2d.velocity.x < -0.5f && facingRight)
        {
            facingRight = !facingRight;
            Vector3 tempScale = trans.localScale;
            tempScale.x *= -1;
            trans.localScale = tempScale;
        }
    }


}
