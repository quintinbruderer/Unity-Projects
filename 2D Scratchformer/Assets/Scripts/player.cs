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
    private bool inAir;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        inAir = false;
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tiles")
        {
            inAir = false;
        }
        if (collision.gameObject.tag == "Finish")
        {
            //you win
        }
    }

    private void playerMovement(float horizontal)
    {
        if (inAir) //rb2d.velocity.y > 0.1f || rb2d.velocity.y < -0.2f
        {
            rb2d.velocity = new Vector2(horizontal * topSpeed * 0.5f, rb2d.velocity.y);
            anim.SetTrigger("idle");
        }
        else
        {
            rb2d.velocity = new Vector2(horizontal * topSpeed, rb2d.velocity.y);

            if (rb2d.velocity.x > 0.5f  && !inAir || rb2d.velocity.x < -0.5f && !inAir)
            {
                anim.SetTrigger("run");
            }
            else
            {
                anim.SetTrigger("idle");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
        {
            rb2d.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            inAir = true;
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
