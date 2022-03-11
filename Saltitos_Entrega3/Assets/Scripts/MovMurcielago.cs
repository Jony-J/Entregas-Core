using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovMurcielago : MonoBehaviour
{
    bool tocaSuelo = false;
    private GameObject arma;
    private GameObject target;
    float cronometro;

    void Start()
    {
        target = GameObject.Find("Player");
        arma = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        cronometro += 1 * Time.deltaTime;
        if (transform.position.y > 10)
        {
            tocaSuelo = !tocaSuelo;
        }

        if (!tocaSuelo)
        {
            transform.Translate(new Vector2(0, -10f * Time.deltaTime));
        }
        else
        {
            transform.Translate(new Vector2(0, 10f * Time.deltaTime));
        }

        if (target.transform.position.y <= transform.position.y)
        {
            arma.GetComponent<Weapon>().Shoot();
            cronometro = 0;
        }

        if (target.transform.position.x <= transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            tocaSuelo = !tocaSuelo;
        }
    }
}
