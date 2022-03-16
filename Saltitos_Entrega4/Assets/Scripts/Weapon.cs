using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform gunSight;
    public GameObject bulletPrefab;
    public float coolDown;
    float cdTimer;

    // Update is called once per frame
    void Update()
    {
        if (cdTimer > 0)
        {
            cdTimer -= Time.deltaTime;
        }
        else if (cdTimer < 0)
        {
            cdTimer = 0;
        }

        if (transform.parent.tag == "player")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        if(cdTimer == 0)
        {
            Instantiate(bulletPrefab, gunSight.position, gunSight.rotation);
            cdTimer = coolDown;
        }
    }
}
