using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int direccion = 1;
    int canJump;
    public float velocidad;
    public float salto;
    public float health;

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

        if(movimientoX > 0 && direccion < 0) 
        {
            Flip();
        }
        if (movimientoX < 0 && direccion > 0)
        {
            Flip();
        }

        if (Input.GetKeyDown("up") && canJump > 0)
        {
            Salto();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ground")
        {
            canJump = 2;
        }

        if (collision.transform.tag == "enemy")
        {
            if (collision.transform.name == "Goblin")
            {
                TakeDamage(40);
            }

            if (collision.transform.name == "Murcielago")
            {
                TakeDamage(10);
            }
        }

        if (collision.transform.tag == "End")
        {
            Debug.Log("Fin del Juego");
            SceneManager.LoadScene("Escena");
        }
    }

    private void Flip()
    {

        if (direccion > 0)
        {
            direccion -= 2;
            transform.Rotate(0, 180, 0);
        }
        else
        {
            direccion += 2;
            transform.Rotate(0, -180, 0);
        }
    }

    private void Salto()
    {
        canJump--;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, salto);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("El " + transform.name + " tiene " + health + " de vida");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (transform.tag == "player")
        {
            SceneManager.LoadScene("Escena");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

