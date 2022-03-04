using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int canJump;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5000f * Time.deltaTime, 0));
        }

        if (Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(5000f * Time.deltaTime, 0));
        }

        if (Input.GetKeyDown("up") && canJump > 0)
        {
            canJump--;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 6000f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ground")
        {
            canJump = 2;
        }
    }
}

