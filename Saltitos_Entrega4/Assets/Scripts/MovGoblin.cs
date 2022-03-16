using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovGoblin : MonoBehaviour
{
    int direccion;
    int rutina;
    float cronometro;
    public float velocidad;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody2D>().name == "Goblin")
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
            Comportamiento();
        }
    }

    private void Comportamiento()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 2)
        {
            
            transform.Rotate(0, 180, 0);
            cronometro = 0;
            /* Poner cuando aprenda a hacer un collision para que no se caiga
             Debug.Log("cronometro = " + cronometro);
            rutina = Random.Range(0, 2);
            cronometro = 0;

            switch (rutina)
            {
                case 0:
                    direccion = Random.Range(0, 2);
                    rutina++;
                    break;

                case 1:
                    if (direccion == 0)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    break;
            }
            */
        }
    }
}