using System;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{

    public GameObject menuPausa;
    public GameObject botonPausa;
    public bool juegoPausado = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is create

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        menuPausa.SetActive(true);
        botonPausa.SetActive(false);
        Time.timeScale = 0;
        juegoPausado = true;
    }

    public void Reanudar()
    {
        menuPausa.SetActive(false);
         botonPausa.SetActive(true);
        Time.timeScale = 1;
        juegoPausado = false;
    }
}
