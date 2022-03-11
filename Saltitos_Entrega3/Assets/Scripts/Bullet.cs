using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public Rigidbody2D rb;
    public Bullet bullet;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "enemy")
        {

            collision.GetComponent<Enemy>().TakeDamage(damage);
                
        }
        if (collision.transform.tag == "player")
        {

            collision.GetComponent<PlayerController>().TakeDamage(damage);

        }

        Debug.Log(collision.name);
        DestroyGameObject();
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
