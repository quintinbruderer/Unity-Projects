using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseai1 : MonoBehaviour
{
    public int speed;
    public bool spawner = false;
    private bool facingLeft;

    private Rigidbody2D rb2d;
    private Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        facingLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(-speed, rb2d.velocity.y); // this is basic spawn movement

        // if spawner is false, add timer for them to move back and forth
        mouseFlip();
    }

    private void mouseFlip()
    {
        if (rb2d.velocity.x > 0.5f && facingLeft || rb2d.velocity.x < -0.5f && !facingLeft)
        {
            facingLeft = !facingLeft;
            Vector3 tempScale = trans.localScale;
            tempScale.x *= -1;
            trans.localScale = tempScale;
        }
    }
}
