using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool facingRight = true;
    int canJump;
    public float velocidad;
    public float salto;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Movement();   
    }

    private void Movement()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movimientoX * velocidad, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if(movimientoX > 0 && !facingRight) 
        {
            Flip();
        }
        if (movimientoX < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown("up") && canJump > 0)
        {
            canJump--;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, salto);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ground")
        {
            canJump = 2;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        if (facingRight)
        {
            transform.Rotate(0, 180, 0);
        }
        else
        {
            transform.Rotate(0, -180, 0);
        }
    }
}

