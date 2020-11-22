using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    
    private bool grounded;
    private Vector3 initialPosition;

    public float speed = 3f;
    public float jumpPower = 5f;

    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
        initialPosition = new Vector3(-9.3f, -1.5f, 1f);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            anim.SetBool("Jumping", true);
        }

        if (h != 0)
        {
            anim.SetBool("Walking", true);

            if (h < 0)
                sprite.flipX = true;
            else
                sprite.flipX = false;
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (transform.position.y < -2.5)
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Floor")
        {
            grounded = true;
            anim.SetBool("Jumping", false);
        }

        if (collision.gameObject.tag == "Enemi")
        {
            Death();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Floor")
        {
            grounded = false;
        }
    }

    public void Death()
    {
        transform.position = initialPosition;
        grounded = true;
        Debug.Log("Te has muerto");

        Life.QuitarVida();
    }
}
