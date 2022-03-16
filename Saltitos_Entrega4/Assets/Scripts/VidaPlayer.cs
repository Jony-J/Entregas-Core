using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    private GameObject player;
    public float healthMax;
    float health;
    public Image barraDeVida;

    // Start is called before the first frame update
    void Start()
    {
        health = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        barraDeVida.fillAmount = health / healthMax;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("El " + transform.name + " tiene " + health + " de " + healthMax);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (transform.tag == "player")
        {
            SceneManager.LoadScene("Juego");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
