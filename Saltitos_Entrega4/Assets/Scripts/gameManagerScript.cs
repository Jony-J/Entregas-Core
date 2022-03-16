using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerScript : MonoBehaviour
{
    public GameObject menuPausa;
    bool pausa = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!pausa)
            {
                pausa = !pausa;
                Pausa();
            }
            else
            {
                pausa = !pausa;
                Reanudar();
            }
        }
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Pausa()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void Salir()
    {
        Application.Quit();
    }
}
